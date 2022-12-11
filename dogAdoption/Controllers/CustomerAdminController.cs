using Microsoft.AspNetCore.Mvc;
using dogAdoption.Models;

namespace dogAdoption.Controllers;

public class CustomerAdminController : Controller
{
    public IActionResult ListOfCustomers()
    {
        return View();
    }

    public IActionResult ListOfAdoptedDogs()
    {
        return View();
    }
}
