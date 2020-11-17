using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;
using System;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests{
        
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
           _name = new Name("Rafael", "Nascimento");
           _document = new Document("62521302066", EDocumentType.CPF);
           _email = new Email("teste@teste.com");
           _address = new Address("Rua ABC", "1234", "Vila Olímpia", "São Paulo", "SP", "Brazil", "12345-123");
           _student = new Student(_name, _document, _email);
           _subscription = new Subscription(null);

          
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription(){
            var payment = new PayPalPayment("12345678",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "NASCIMENTO CORP", _document, _address, _email);
           _subscription.AddPayment(payment);
           _student.AddSubscription(_subscription);
           _student.AddSubscription(_subscription);

           Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment(){
           _student.AddSubscription(_subscription);
           Assert.IsTrue(_student.Invalid);
        }


       [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription(){
           var payment = new PayPalPayment("12345678",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "NASCIMENTO CORP", _document, _address, _email);
           _subscription.AddPayment(payment);
           _student.AddSubscription(_subscription);
           Assert.IsTrue(_student.Valid);
        }

    }

}