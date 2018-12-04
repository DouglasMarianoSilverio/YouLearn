using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{
    public class UsuarioController : YouLearn.Api.Controllers.Base.ControllerBase
    {

        private readonly IServiceUsuario _serviceUsuario;

        public UsuarioController(IUnitOfWork unitOfWork, IServiceUsuario serviceUsuario) : base(unitOfWork)
        {
            _serviceUsuario = serviceUsuario;
        }

        [HttpPost]
        [Route("api/v1/Usuario/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarUsuarioRequest request)
        {
            try {
                var response = _serviceUsuario.AdicionarUsuario(request);
                return await ResponseAsync(response, _serviceUsuario);
            }
            catch(Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }

        }
    }
}
