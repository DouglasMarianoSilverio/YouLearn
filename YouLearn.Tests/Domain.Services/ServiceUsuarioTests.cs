using Xunit;
using Xunit.Abstractions;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Services;

namespace YouLearn.Tests.Domain.Services
{
    public class ServiceUsuarioTests
    {
        private readonly ITestOutputHelper output;
        private readonly IServiceUsuario serviceUsuario;

        public ServiceUsuarioTests(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
            this.serviceUsuario = new ServiceUsuario();
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
