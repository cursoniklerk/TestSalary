using Common;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using Service.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeForGridView> GetAllByUser();
        IEnumerable<EmployeeForGridView> GetAllById(int? id);
    }

    public class EmployeeService : IEmployeeService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Model.Domain.Employee> _employeeRepository;

        public EmployeeService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Model.Domain.Employee> EmployeeRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _employeeRepository = EmployeeRepository;
        }

        public IEnumerable<EmployeeForGridView> GetAllByUser()
        {
            var result = new List<EmployeeForGridView>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _employeeRepository.GetAllApi("http://masglobaltestapi.azurewebsites.net/api/Employees")
                        .Select(x => new EmployeeForGridView
                        {
                            Id =  x.Id,
                            Name = x.Name,
                            ContractTypeName = x.ContractTypeName == Enums.ContractType.HourlySalaryEmployee ? "Hourly Salary" : "Monthly Salary",
                            RoleName = x.RoleName,
                            RoleDescription = x.RoleDescription == null ? "" : x.RoleDescription.ToString(),
                            HourlySalary = x.HourlySalary,
                            MonthlySalary = x.MonthlySalary,
                            AnualSalary =  new SalaryFactory().Calculate(x)
                        }).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<EmployeeForGridView> GetAllById(int? id)
        {
            var result = new List<EmployeeForGridView>();
            try
            {
                result = GetAllByUser().Where(e=> e.Id == id).ToList();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

    }
}
