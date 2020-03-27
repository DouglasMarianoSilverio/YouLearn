using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Services
{

    public class ServicePlayList : Notifiable, IServicePlayList

    {

        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryPlayList  _repositoryPlayList;

        public PlayListResponse AdicionarPlayList(AdicionarPlayListRequest request, Guid idUsuario)
        {
            Usuario usuario = _repositoryUsuario.Obter(idUsuario);
            PlayList playlist = new PlayList(request.Nome,usuario );
            AddNotifications(playlist);
            if (this.IsInvalid())
            {
                return null;
            }
            playlist = _repositoryPlayList.Adicionar(playlist);
            return (PlayListResponse)playlist;
        }

        public Arguments.Base.Response ExcluirPlayList(Guid id)
        {
            bool existe = false; // _repositoryVideo.ExistePlayListAssociada(id);
            if (existe)
            {
                AddNotification("PlayList", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("PlayList", "Video"));
                 
            }
            PlayList playlist = _repositoryPlayList.Obter(id);

            if(playlist == null)
            {
                AddNotification("PlayList", MSG.DADOS_NAO_ENCONTRADOS);
            }
            if (IsInvalid())
            {
                return null;
            }

            _repositoryPlayList.Excluir(playlist);
            return new Arguments.Base.Response { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<PlayListResponse> Listar(Guid idUsuario)
        {
            IEnumerable<PlayList> playListCollection = _repositoryPlayList.Listar(idUsuario);
            var response = playListCollection.ToList().Select(entidate => (PlayListResponse)entidate);
            return response;
        }
    }
}
