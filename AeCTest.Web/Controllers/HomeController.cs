using AeCTest.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AeCTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {            
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index","Enderecos");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
