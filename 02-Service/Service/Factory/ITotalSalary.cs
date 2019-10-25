using Common;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Factory
{

    public interface ITotalSalary
    {
        /// <summary>
        /// Interface of the operation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        long Operation(long value);
    }
}
