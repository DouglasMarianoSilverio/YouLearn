using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Services
{

    public class ServiceVideo : Notifiable, IServiceVideo

    {
        private readonly IRepositoryCanal _repositoryCanal;
        private readonly IRepositoryPlayList _repositoryPlayList;
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryVideo _repositoryVideo;

        public ServiceVideo(IRepositoryCanal repositoryCanal, IRepositoryPlayList repositoryPlayList, IRepositoryUsuario repositoryUsuario, IRepositoryVideo repositoryVideo)
        {
            _repositoryCanal = repositoryCanal;
            _repositoryPlayList = repositoryPlayList;
            _repositoryUsuario = repositoryUsuario;
            _repositoryVideo = repositoryVideo;
        }

        public AdicionarVideoResponse AdicionarVideo(AdicionarVideoRequest request, Guid id)
        {
            if (request == null)
                AddNotification("AdicionarVideoRequest", MSG.X0_NAO_INFORMADO.ToFormat("AdicionarVideoRequest"));
           
            var usuario = _repositoryUsuario.Obter(id);
            if (usuario == null)
                AddNotification("Usuario", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Usuario"));

            var canal = _repositoryCanal.Obter(request.IdCanal);
            if (canal == null)
                AddNotification("Canal", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Canal"));

            PlayList playList = null;

            if (request.IdPlayList != Guid.Empty)
            {
                playList = _repositoryPlayList.Obter(request.IdPlayList);

                if (playList == null)
                    AddNotification("PlayList", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("PlayList"));
            }

            Video video = new Video(canal, playList, request.Titulo, request.Descricao, request.Tags, request.OrdemNaPlaylist, request.IdVideoYoutube, usuario);
            AddNotifications(video);

            if( this.IsInvalid())
            {
                return null;
            };
             _repositoryVideo.Adicionar(video);
            return new AdicionarVideoResponse(video.Id);       

        }

        public Arguments.Base.Response ExcluirVideo(Guid idVideo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VideoResponse> Listar(string tags)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.Listar(tags);
            return videoCollection.ToList()
                                  .Select(entidade => (VideoResponse)entidade);
        }

        public IEnumerable<VideoResponse> Listar(Guid idPlayList)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.Listar(idPlayList);
            return videoCollection.ToList()
                                  .Select(entidade => (VideoResponse)entidade);
        }

       
    }
}
