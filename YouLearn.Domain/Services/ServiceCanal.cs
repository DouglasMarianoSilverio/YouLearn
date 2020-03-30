using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Services
{

    public class ServiceCanal : Notifiable, IServiceCanal

    {

        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryCanal _repositoryCanal;
        private readonly IRepositoryVideo _repositoryVideo;

        public ServiceCanal(IRepositoryUsuario repositoryUsuario, IRepositoryCanal repositoryCanal, IRepositoryVideo repositoryVideo)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryCanal = repositoryCanal;
            _repositoryVideo = repositoryVideo;
        }

        public CanalResponse AdicionarCanal(AdicionarCanalRequest request, Guid id)
        {
            Usuario usuario = _repositoryUsuario.Obter(id);
            Canal canal = new Canal(request.Nome, request.UrlLogo, usuario);
            AddNotifications(canal);
            if( this.IsInvalid())
            {
                return null;
            }
            canal = _repositoryCanal.Adicionar(canal);
            return (CanalResponse)canal;         

        }

        public Arguments.Base.Response ExcluirCanal(Guid idCanal)
        {
            bool existe = _repositoryVideo.ExisteCanalAssociado(idCanal);
            if (existe)
            {
                AddNotification("PlayList", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("canal", "video"));

            }
            Canal canal = _repositoryCanal.Obter(idCanal);

            if (canal == null)
            {
                AddNotification("Canal", MSG.DADOS_NAO_ENCONTRADOS);
            }
            if (IsInvalid())
            {
                return null;
            }

            _repositoryCanal.Excluir(canal);
            return new Arguments.Base.Response { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<CanalResponse> Listar(Guid idUsuario)
        {
            IEnumerable<Canal> canalCollection = _repositoryCanal.Listar(idUsuario);
            var response = canalCollection.ToList().Select(entidate => (CanalResponse)entidate);
            return response;
        }
    }
}
