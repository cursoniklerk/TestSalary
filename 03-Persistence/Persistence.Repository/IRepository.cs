using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repository
{
    public interface IRepository<T>
    {

        /// <summary>
        /// Retorna un objeto que obtiene desde una api REST
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IList<Employee> GetAllApi(string url, params Expression<Func<T, object>>[] includeProperties);

    }
}
