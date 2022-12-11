using Microsoft.AspNetCore.Mvc;
using dogAdoption.Models;

namespace dogAdoption.Controllers;

public class AdminController : Controller
{
    public IActionResult MainAdmin()
    {
        return View();
    }
}
