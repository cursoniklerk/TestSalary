using Common;
using Model.Custom;
using Model.Domain;
using NLog;
using Service;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService = DependecyFactory.GetInstance<IEmployeeService>();

        public ActionResult Index(int? Id)
        {
            if (Id > 0)
                return View(_employeeService.GetAllById(Id));
            else if (Id < 1)
                return View(_employeeService.GetAllByUser());
            else
                return View(new List<EmployeeForGridView>());
        }
    }
}