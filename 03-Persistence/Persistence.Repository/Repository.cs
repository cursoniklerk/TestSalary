using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Persistence.DbContextScope;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Globalization;

namespace Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;

        public Repository(IAmbientDbContextLocator context)
        {
            _ambientDbContextLocator = context;
        }


        public IList<Employee> GetAllApi(string url, params Expression<Func<T, object>>[] includeProperties)
        {
            var client = new WebClient();
            var response = client.DownloadString(url);
            var welcome = Employee.FromJson(response);
            return welcome.ToList();
        }

    }
}