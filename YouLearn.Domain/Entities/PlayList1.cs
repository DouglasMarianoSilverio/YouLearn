using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Entities
{
    public class PlayList : EntityBase
    {
        protected PlayList()
        {

        }
        public PlayList(string nome, Usuario usuario)
        {
            Nome = nome;
            Usuario = usuario;
            Status = EnumStatus.EmAnalise;
            new AddNotifications<PlayList>(this)
              .IfNullOrInvalidLength(p => p.Nome, 2, 100, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("2", "100"));

            AddNotifications(usuario);

        }

        public PlayList(string nome, Usuario usuario, EnumStatus status)
        {
            Nome = nome;
            Usuario = usuario;
            Status = status;
            new AddNotifications<PlayList>(this)
              .IfNullOrInvalidLength(p => p.Nome, 2, 100, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("2", "100"));

        }

        public string Nome { get; private set; }
        public Usuario Usuario { get; private set; }
        public EnumStatus  Status { get; private set; }

      

    }
}
