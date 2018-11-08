using prmToolkit.NotificationPattern;
using System;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Services;

namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario 
    {
        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if(request ==null)
            {
                throw new Exception("Objeto AdicionarUsuarioRequest Obrigatorio");
            }
            Usuario usuario = new Usuario();
            usuario.Nome.PrimeiroNome = "Douglas";
            usuario.Nome.UltimoNome = "Silverio";
            usuario.Email.Endereco = "douglas07@gmail.com";
            usuario.Senha = "123456";

            if (usuario.Nome.PrimeiroNome.Length < 3 || usuario.Nome.PrimeiroNome.Length > 50)
            {
                throw new Exception("Primeiro nome é obrigatorio ter entre 3 e 50 caracteres.");
            }

            if (usuario.Nome.UltimoNome.Length < 3 || usuario.Nome.UltimoNome.Length > 50)
            {
                throw new Exception("Ultimo nome é obrigatorio ter entre 3 e 50 caracteres.");
            }

            if (usuario.Email.Endereco.IndexOf("@",0) < 1)
            {
                throw new Exception("Email invalido.");
            }

            if (usuario.Senha.Length < 3)
            {
                throw new Exception("Senha tem que ter ao menos 3 caracteres.");
            }
            //persiste
            return new AdicionarUsuarioResponse(Guid.NewGuid());


        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest  request)
        {
            throw new System.NotImplementedException();
        }
    }
}
