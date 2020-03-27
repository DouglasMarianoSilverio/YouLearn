using Newtonsoft.Json;
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
        private readonly ITestOutputHelper _output;
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IRepositoryUsuario _repositoryUsuario;


        public ServiceUsuarioTests(ITestOutputHelper testOutputHelper)
        {
            _output = testOutputHelper;
            
            this._repositoryUsuario = new RepositoryUsuario( new Infra.Persistence.EF.YouLearnContext());
            this._serviceUsuario = new ServiceUsuario(_repositoryUsuario);
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
            var response = _serviceUsuario.AdicionarUsuario(adicionarUsuarioRequest);
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
