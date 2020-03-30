using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryVideo : IRepositoryVideo
    {

        private readonly YouLearnContext _context;

        public RepositoryVideo(YouLearnContext context)
        {
            _context = context;
        }

        public void Adicionar(Video video)
        {
            _context.Videos.Add(video);
        }

        public bool ExisteCanalAssociado(Guid idCanal)
        {
            return _context.Videos.Any(v => v.Canal.Id == idCanal);
        }

        public bool ExistePlayListAssociada(Guid idPlayList)
        {
            return _context.Videos.Any(v => v.Playlist.Id == idPlayList);
        }

        public IEnumerable<Video> Listar(string tags)
        {
            var query = _context.Videos
               .Include(v => v.Canal)
               .Include(v => v.Playlist)
               .AsQueryable();

            tags.Split(' ').ToList().ForEach(tag => {
                query = query.Where(v => v.Tags.Contains(tag) || v.Titulo.Contains(tag) || v.Descricao.Contains(tag));

            } ); 
            
            return query.ToList();
        }

        public IEnumerable<Video> Listar(Guid idPlayList)
        {
            return _context.Videos
                .Include(v => v.Canal)
                .Include(v => v.Playlist)
                .Where(v => v.Playlist.Id == idPlayList).ToList();
        }
    }
}
