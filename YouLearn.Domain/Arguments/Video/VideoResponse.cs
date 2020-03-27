using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.Video
{
    public class VideoResponse
    {
        public string NomeCanal { get; set; }
        public Guid? IdPlayList { get; set; }
        public string NomePlaylist { get; set; }
        public string Titulo { get; set; }
        public string Decricao { get; set; }
        public string Thumbnail { get; set; }
        public string IdVideoYoutube { get; set; }
        public int? OrdemNaPlayList { get; set; }
        public string Url { get; set; }

        public static explicit operator VideoResponse(Entities.Video entity)
        {
            return new VideoResponse
            {
                Decricao = entity.Descricao,
                Url = $"https://www.youtube.com/embed/{entity.IdVideoYoutube}",
                NomeCanal = entity.Canal.Nome,
                IdVideoYoutube = entity.IdVideoYoutube,
                Thumbnail = $"https://img.youtube.com/vi/{entity.IdVideoYoutube}/mqdefault.jpg",
                Titulo = entity.Titulo,
                IdPlayList = entity.Playlist?.Id,
                NomePlaylist = entity.Playlist?.Nome,
                OrdemNaPlayList= entity.OrdemNaPlaylist           
            }; 
             
        }
    }
}
