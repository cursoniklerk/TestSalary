using Common;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Factory
{
    class MonthlySalaryEmployee : ITotalSalary
    {
        /// <summary>
        /// Do the operation to the Monthly Salary
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public long Operation(long value)
        {
            return value * 12;
        }
    }

}
