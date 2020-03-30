using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using YouLearn.Api.Security;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Services;
using YouLearn.Infra.Persistence.EF;
using YouLearn.Infra.Persistence.Repositories;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api
{
    public class Startup
    {
        private const string ISSUER = "http://localhost:63939/";
        private const string AUDIENCE = "http://localhost:63939/";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddScoped<YouLearnContext,YouLearnContext>();
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services
            services.AddTransient<IServiceCanal, ServiceCanal>();
            services.AddTransient<IServicePlayList, ServicePlayList>();
            services.AddTransient<IServiceVideo, ServiceVideo>();
            services.AddTransient<IServiceUsuario, ServiceUsuario>();

            //repositories
            services.AddTransient<IRepositoryCanal, RepositoryCanal>();
            services.AddTransient<IRepositoryPlayList, RepositoryPlayList>();
            services.AddTransient<IRepositoryVideo, RepositoryVideo>();
            services.AddTransient<IRepositoryUsuario, RepositoryUsuario>();

            //token configuration
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations
            { Audience = AUDIENCE ,
              Issuer = ISSUER,
              Seconds = int.Parse(TimeSpan.FromDays(1).TotalSeconds.ToString())};

            services.AddSingleton(tokenConfigurations);
            services.AddAuthentication(authOptions =>
            { 
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidations = bearerOptions.TokenValidationParameters;
                paramsValidations.IssuerSigningKey = signingConfigurations.SigningCredentials.Key;
                paramsValidations.ValidAudience = tokenConfigurations.Audience;
                paramsValidations.ValidIssuer = tokenConfigurations.Issuer;

                //Validates received token signature
                paramsValidations.ValidateIssuerSigningKey = true;

                //checks if received token is valid.
                paramsValidations.ValidateLifetime = true;

                //expiration tolerancy time(to be used when the computers envolved at procces has sync problems.
                paramsValidations.ClockSkew = TimeSpan.Zero;
                //paramsValidations.RequireExpirationTime = true;
            });

            //active token as access authorization method to project resources
            services.AddAuthorization(auth => 
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build()) ;
            });

            services.AddMvc( config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddCors();


            services.AddSwaggerGen(x  =>
            {
                x.SwaggerDoc("v1", new Info { Title = "YouLearn", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c => {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            }); 

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI( c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "YouLearn - V1");
            });
            
        }
    }
}
