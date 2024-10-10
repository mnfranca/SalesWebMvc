using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public ActionResult Index()
        {
            List<Department> list = [];
            list.Add(new Department { Id = 1, Name = "Eletronics" });
            list.Add(new Department { Id = 2, Name = "Fashion" });

            return View(list);
        }

    }
}
