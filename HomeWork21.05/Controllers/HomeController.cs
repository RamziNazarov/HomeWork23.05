using Microsoft.AspNetCore.Mvc;
using HomeWork21._05.Models;

namespace HomeWork21._05.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Persons = new Person().ReadAll();
            return View();
        }
    }
}
