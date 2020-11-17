using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Commands;
using System;

namespace PaymentContext.Tests
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests{
        
        /*Apenas um exemplo rápido, para mostrar que é possível também testar os commands, caso assim seja necessário*/
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid(){
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";
            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }

    }

}
