using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace DemoMVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}