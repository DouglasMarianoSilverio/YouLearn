using System;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class Video : EntityBase
    {
        public Canal Canal { get; private set; }
        public Playlist Playlist { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Tags { get; private set; }
        public int OrdemNaPlaylist { get; private set; }
        public string IdVideoYoutube { get; private set; }
        public Usuario UsuarioSugeriu { get; private set; }
        public EnumStatus Status { get; private set; }
    }
}
