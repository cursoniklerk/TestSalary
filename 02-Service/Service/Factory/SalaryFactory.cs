using Common;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Factory
{
    public class SalaryFactory
    {
        /// <summary>
        /// Logic to calculate the Anual Salary of the Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public long Calculate(Employee employee)
        {
            long value = 0;
            if (employee.ContractTypeName == Enums.ContractType.HourlySalaryEmployee)
                value = new HourlySalaryEmployee().Operation(employee.HourlySalary);
            else
                value = new MonthlySalaryEmployee().Operation(employee.MonthlySalary);
            return value;
        }
    }
}
