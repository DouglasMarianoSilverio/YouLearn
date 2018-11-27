using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public bool Existe(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario Obter(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
