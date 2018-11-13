﻿using prmToolkit.NotificationPattern;
<<<<<<< HEAD
using prmToolkit.NotificationPattern.Extensions;
=======
>>>>>>> 491f5a4b0e68118431d4b3f7a29475c327fba264
using System;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
 
    public class ServiceUsuario : Notifiable, IServiceUsuario
 
    {
        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if (request == null)
            {

                AddNotification("AdicionarUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUsuarioRequest"));
                return null;
            }

            Nome nome = new Nome( request.PrimeiroNome,request.UltimoNome);
        

            Email email = new Email(request.Email);




            Usuario usuario = new Usuario(
           nome, email, request.Senha);
            

            AddNotifications(nome, email,usuario);


      
            //persiste
            return new AdicionarUsuarioResponse(Guid.NewGuid());


        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
