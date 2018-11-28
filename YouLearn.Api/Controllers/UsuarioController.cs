using Microsoft.AspNetCore.Mvc;
using YouLearn.Domain.Arguments.Usuario;
using System.Threading.Tasks;
using YouLearn.Domain.Services;
using YouLearn.Domain.Interfaces.Services;
using System;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Api.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IServiceUsuario serviceUsuario;
        

        public UsuarioController(ServiceUsuario serviceUsuario)
        {
            this.serviceUsuario = serviceUsuario;
        }

        [HttpPost]
        [Route("api/v1/Usuario/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarUsuarioRequest request)
        {
            try {
                //var response = serviceUsuario.AdicionarUsuario(request);
                //return await ResposeAsync(reponse, _serviceUsuario);
            }
            catch(Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }

        }
    }
}
