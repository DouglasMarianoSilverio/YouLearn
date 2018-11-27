using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Extensions;
using System;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            AddNotifications(Email); 

            Senha = Senha.ConvertToMD5();
        }

        public Usuario(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;

            AddNotifications(Nome, Email);

            new AddNotifications<Usuario>(this)
                .IfLengthLowerThan(x => x.Senha, 3, MSG.X0_E_OBRIGATORIA_E_DEVE_CONTER_X1_CARACTERES.ToFormat("Senha", 4));

            Senha = Senha.ConvertToMD5();
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }



    }
}
