using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{


    public class CanalController : Base.ControllerBase
    {
        private readonly IServiceCanal _serviceCanal;

        public CanalController(IUnitOfWork unitOfWork , IServiceCanal serviceCanal) : base(unitOfWork)
        {
            _serviceCanal = serviceCanal;
        }

        [HttpGet]
        [Route("api/v1/Canal/Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                Guid idusuario = Guid.NewGuid();
                var response = _serviceCanal.Listar(idusuario);
                return await ResponseAsync(response, _serviceCanal);

            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("api/v1/Canal/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarCanalRequest request )
        {
            try
            {
                Guid idusuario = Guid.NewGuid();
                var response = _serviceCanal.AdicionarCanal(request, idusuario);
                return await ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/Canal/Excluir")]
        public async Task<IActionResult> Excluir(Guid idCanal)
        {
            try
            {                
                var response = _serviceCanal.ExcluirCanal(id);
                return await ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
    }
}