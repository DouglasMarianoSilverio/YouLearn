using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{


    public class PlayListController : Base.ControllerBase
    {

        private readonly IServicePlayList _servicePlayList;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlayListController(IUnitOfWork unitOfWork, IServicePlayList servicePlayList, IHttpContextAccessor httpContextAccessor) : base(unitOfWork)
        {
            _servicePlayList = servicePlayList;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("api/v1/PlayList/Listar")]       
        public async Task<IActionResult> Listar()
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _servicePlayList.Listar(usuarioResponse.Id);
                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex); 
            }
        }

        [HttpPost]
        [Route("api/v1/PlayList/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarPlayListRequest request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _servicePlayList.AdicionarPlayList(request, usuarioResponse.Id);
                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/PlayList/Excluir")]
        public async Task<IActionResult> Excluir(Guid idPlayList)
        {
            try
            {
                var response = _servicePlayList.ExcluirPlayList(idPlayList);
                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }


    }
}