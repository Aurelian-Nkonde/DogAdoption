using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dogAdoption.Models;
using System.Collections.Generic;

namespace dogAdoption.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}