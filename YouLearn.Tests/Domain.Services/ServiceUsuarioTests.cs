using Xunit;
using Xunit.Abstractions;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Services;
using YouLearn.Infra.Persistence.Repositories;

namespace YouLearn.Tests.Domain.Services
{
    public class ServiceUsuarioTests
    {
        private readonly ITestOutputHelper output;
        private readonly IServiceUsuario serviceUsuario;
        private readonly IRepositoryUsuario repositoryUsuario;


        public ServiceUsuarioTests(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
            
            this.repositoryUsuario = new RepositoryUsuario( new Infra.Persistence.EF.YouLearnContext());
            this.serviceUsuario = new ServiceUsuario(repositoryUsuario);
        }

        [Fact]
        public void DeveAdicionarUsuario()
        {
            AdicionarUsuarioRequest adicionarUsuarioRequest = new AdicionarUsuarioRequest
            {
                PrimeiroNome = "Douglas",
                UltimoNome = "Silveiro",
                Email = "douglas07@gmail.com",
                Senha = "12"
            };
            var response = serviceUsuario.AdicionarUsuario(adicionarUsuarioRequest);
        }
    }
}
