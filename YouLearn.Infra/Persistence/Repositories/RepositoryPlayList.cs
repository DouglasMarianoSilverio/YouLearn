using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryPlayList : IRepositoryPlayList
    {
        private readonly YouLearnContext _context;

        public RepositoryPlayList(YouLearnContext context)
        {
            _context = context;
        }

        public PlayList Adicionar(PlayList PlayList)
        {
            _context.PlayLists.Add(PlayList);
            return PlayList;
        }

        public void Excluir(PlayList PlayList)
        {
            _context.PlayLists.Remove(PlayList);
        }

        public IEnumerable<PlayList> Listar(Guid idUsuario)
        {
           return  _context.PlayLists.Where(c => c.Usuario.Id == idUsuario).ToList();
        }

        public PlayList Obter(Guid id)
        {
            return _context.PlayLists.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
