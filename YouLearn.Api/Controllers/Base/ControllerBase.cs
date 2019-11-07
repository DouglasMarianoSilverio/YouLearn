using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Domain.Interfaces.Services.Base;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers.Base
{
    public class ControllerBase : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServiceBase _serviceBase;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ResponseAsync(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;
            if (!_serviceBase.Notifications.Any())
            {
                try
                {
                    _unitOfWork.Commit();
                    return Ok(result);
                    //return Request.CreateResponse(HttpStatusCode.Ok, result);
                }
                catch(Exception ex)
                {
                    return  BadRequest($"Houve um problema interno com o servidor. Entre em contato");
                    
                }
            }
            else
            {
                return  BadRequest(new { errors = _serviceBase.Notifications });
            }
        }

        public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
        {
            return BadRequest(new { erros = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            if (_serviceBase != null)
            {
                _serviceBase.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
