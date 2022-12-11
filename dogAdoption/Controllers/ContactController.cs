using Microsoft.AspNetCore.Mvc;
using dogAdoption.Models;

namespace dogAdoption.Controllers;

public class ContactController : Controller
{
    public IActionResult Contact()
    {
        return View();
    }
}
