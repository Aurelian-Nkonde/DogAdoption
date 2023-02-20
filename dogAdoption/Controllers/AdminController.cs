using Microsoft.AspNetCore.Mvc;
using dogAdoption.Models;
using System.Collections.Generic;

namespace dogAdoption.Controllers;

public class AdminController : Controller
{
    public IActionResult MainAdmin()
    {
        return View();
    }
}
