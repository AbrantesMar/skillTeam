using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillTeam.Controllers;
using SkillTeam.Models.Repository;
using Moq;
using System;
using MongoDB.Bson;

namespace SkillTeamTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IEmployeeRepository> mock;

        [TestMethod]
        public void TestMethod1()
        {
            mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.FindById(ObjectId("507f1f77bcf86cd799439011")).Returns("Testando"));
            EmployeeController employeeController = new EmployeeController(mock.Object);
            string result = employeeController.FindEmployeeById(ObjectId("507f1f77bcf86cd799439011")).Description;
            Console.Write("testando");
            Assert.AreEqual("Testando", result);
        }
    }
}
