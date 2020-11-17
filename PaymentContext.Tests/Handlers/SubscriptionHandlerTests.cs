using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Commands;
using System;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests{
        
        /*Apenas um exemplo rápido, para mostrar que é possível também testar os commands, caso assim seja necessário*/
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists(){
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Rafael";
            command.LastName = "Nascimento";
            command.Document = "99999999999";
            command.Email = "rafa@io.com";
            command.BarCode = "123456789";
            command.BoletoNumber = "1234567897";
            command.PaymentNumber = "897654321";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Rafael Corp.";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "rafa@io.com";
            command.Street = "Rua Teste";
            command.Number = "10";
            command.Neighborhood = "Vila Olímpia";
            command.City = "São Paulo";
            command.State = "SP";
            command.Country = "Brasil";
            command.ZipCode = "10823-101";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid); 
        }
    }
}
