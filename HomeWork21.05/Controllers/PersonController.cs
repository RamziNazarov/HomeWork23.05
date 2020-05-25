using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeWork21._05.Models;

namespace HomeWork21._05.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(ViewBag.Persons = new Person().ReadAll());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(string FirstName, string LastName, string MiddleName)
        {
            Person person = new Person()
            {
                FirstName = FirstName,
                LastName = LastName,
                MiddleName = MiddleName
            };
            person.AddOnePerson(person);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ReadById()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReadById(int id)
        {
            if (!string.IsNullOrEmpty(id.ToString()) && id >0)
            {
                return View(ViewBag.Person = new Person().ReadById(id));
            }
            return View();
        }
        [HttpGet]
        public IActionResult SearchByFLM()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchByFLM(string FirstName, string LastName, string MiddleName)
        {
            return View(ViewBag.Person = new Person().SearchByFLM(FirstName, LastName, MiddleName));
        }
    }
}
