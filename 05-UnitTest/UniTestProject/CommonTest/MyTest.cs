using System;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence.Repository;
using Service.Factory;

namespace UniTestProject.CommonTest
{
    [TestClass]
    public class MyTest
    {
        [TestMethod]
        public void HourlySalaryTest()
        {
            var valor = 20;
            var original = 120 * valor * 12;
            var n = new SalaryFactory();
            var e = new Employee()
            {
                HourlySalary = 20,
                ContractTypeName = Enums.ContractType.HourlySalaryEmployee
            };

            var result = n.Calculate(e);
            
            Assert.IsTrue(original == result);
        }

        [TestMethod]
        public void MonthlySalaryTest()
        {
            var valor = 20;
            var original = valor * 12;
            var n = new SalaryFactory();
            var e = new Employee()
            {
                MonthlySalary = valor,
                ContractTypeName = Enums.ContractType.MonthlySalaryEmployee
            };

            var result = n.Calculate(e);

            Assert.IsTrue(original == result);
        }
    }
}
