using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        //Red, Green, Refactor
        //Primeiro ponto, escreverem os testes, fazerem os testes falharem
        //Depois, fazer os testes passarem..
        //Por último, refatorar o código
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid(){
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid(){
            var doc = new Document("31208202000157", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid(){
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("88625241026")]
        [DataRow("10334774004")]
        [DataRow("38010711039")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf){
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }

    }
}