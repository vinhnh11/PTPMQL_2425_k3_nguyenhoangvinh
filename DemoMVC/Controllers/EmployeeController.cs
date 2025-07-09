using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace EmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }
    }
}