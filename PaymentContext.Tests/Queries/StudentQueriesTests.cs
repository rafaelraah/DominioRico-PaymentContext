using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;
using System.Collections.Generic;
using PaymentContext.Domain.Queries;
using System.Linq;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        //Red, Green, Refactor

        private IList<Student> _students;

        public StudentQueriesTests(){
            _students = new List<Student>();
            for(var i = 0; i <= 10; i++)
            {
                _students.Add(
                    new Student(
                            new Name("Aluno", i.ToString()), 
                            new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                            new Email(i.ToString() + "@rafa.io")
                        )
                );
            }
        }

        [TestMethod]
        public void SholdReturnStudentWhenDocumentExists(){
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreNotEqual(null, student);
        }

    }
}