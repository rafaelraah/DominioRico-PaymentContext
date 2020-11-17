using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
         public string FirstName {get; set;}
         public string LastName {get; set;}
         public string Document { get; set; }
         public string Email { get; set; }
         public string BarCode { get; set; }
         public string BoletoNumber { get; set; }
         public string PaymentNumber { get; set; }
         public DateTime PaidDate { get; set; }
         public DateTime ExpireDate { get; set; }   
         public decimal Total { get; set; }
         public decimal TotalPaid { get; set; }
         public string Payer { get; set;}
         public string PayerDocument { get; set; }
         public EDocumentType PayerDocumentType { get; set;}
         public string PayerEmail { get; set; }
         public string Street { get; set; }
         public string Number { get; set; }
         public string Neighborhood { get; set; }
         public string City { get; set; }
         public string State { get; set; }
         public string Country { get; set; }
         public string ZipCode { get; set; }

        /*
            Fail Fast Validations
            Muito interessnte utilizar as validações já aqui no Command, pois já detecta a entrada errada de dados da maneira mais rápida possível,
            ao invés de ir validando, por exemplo, fazendo requisições no banco para validar um CNPJ, depois uma data, algum pagamento etc.. 
            Então, dessa maneira, temos um ganho bastante significativo na performance, dependendo da aplicação.
            Se o command não for valido, eu nem prossigo para o meu domínio, nem dou sequencia nas requisições.
        */
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
            );
        }
    }
}