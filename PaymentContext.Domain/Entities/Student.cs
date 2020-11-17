using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        
        public Student(Name name, Document document, Email email)
        {
            Name = name; 
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            //Agrupando todos os erros que deram no Name, Document e Email, agora sendo notificações de Student
            AddNotifications(name, document, email);

        }

        public Name Name {get; private set;}
        public Document Document {get; private set;}
        public Email Email {get; private set;} 
        public Address Address { get; private set;}
        public IReadOnlyCollection<Subscription> Subscriptions {get {return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            /*//Se já tiver uma assinatur ativa, cancela
            //Cancela todas as outras assinaturas, e coloca esta como principal
            //Método antigo, porém, válido.
            foreach(var sub in Subscriptions){
                sub.Inactivate();
            }
            //_subscriptions.Add(subscription);
            */

            //Trabalhando com as notificações abaixo

            if(subscription.Payments.Count == 0){

            }

            var hasSubscriptionActive = false;
            foreach(var sub in _subscriptions){
                if(sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
            .Requires()
            .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
            //Adiciona uma notificação se for igual à zero
            .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
            );

            _subscriptions.Add(subscription);

            //Alternativa, utilizando direto a booleana.
            if(hasSubscriptionActive)
                AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");

        }

    }
}