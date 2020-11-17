using System;
using System.Collections.Generic;
using Flunt.Notifications;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        //Se fosse utilizar as notificações sem o Flunt, biblioteca do Balta.
        //private IList<string> Notifications;
        public Entity(){
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
    }
}