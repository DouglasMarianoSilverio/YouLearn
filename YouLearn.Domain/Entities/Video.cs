using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Entities
{
    public class Video : EntityBase
    {
        protected Video()
        {

        }
        public Video(Canal canal, PlayList playlist, string titulo, string descricao, string tags, int? ordemNaPlaylist, string idVideoYoutube, Usuario usuarioSugeriu)
        {
            Canal = canal;
            Playlist = playlist;
            Titulo = titulo;
            Descricao = descricao;
            Tags = tags;
            OrdemNaPlaylist = ordemNaPlaylist ?? 0;
            IdVideoYoutube = idVideoYoutube;
            UsuarioSugeriu = usuarioSugeriu;
            Status = EnumStatus.EmAnalise;

            new AddNotifications<Video>(this)
                .IfNullOrInvalidLength(v => v.Titulo, 1, 200, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("1", "200"))
                 .IfNullOrInvalidLength(v => v.Descricao, 1, 255, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("1", "255"))
                  .IfNullOrInvalidLength(v => v.Tags, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("1", "50"))
                   .IfNullOrInvalidLength(v => v.IdVideoYoutube, 1, 50, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("1", "50"));

            AddNotifications(canal);
            AddNotifications(playlist);


        }

        public Canal Canal { get; private set; }
        public PlayList Playlist { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Tags { get; private set; }
        public int OrdemNaPlaylist { get; private set; }
        public string IdVideoYoutube { get; private set; }
        public Usuario UsuarioSugeriu { get; private set; }
        public EnumStatus Status { get; private set; }
    }
}
