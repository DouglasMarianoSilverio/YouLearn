using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryCanal : IRepositoryCanal
    {
        private readonly YouLearnContext _context;

        public RepositoryCanal(YouLearnContext context)
        {
            _context = context;
        }

        public Canal Adicionar(Canal canal)
        {
            _context.Canais.Add(canal);
            return canal;
        }

        public void Excluir(Canal canal)
        {
            _context.Canais.Remove(canal);
        }

        public IEnumerable<Canal> Listar(Guid idUsuario)
        {
           return  _context.Canais.Where(c => c.Usuario.Id == idUsuario).ToList();
        }

        public Canal Obter(Guid id)
        {
            return _context.Canais.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
