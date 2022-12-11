using Microsoft.AspNetCore.Mvc;
using dogAdoption.Models;
using dogAdoption.Data;


namespace dogAdoption.Controllers;

public class AdoptionRequestController : Controller
{
    private readonly AppDbContext _databaseContext;
    public AdoptionRequestController(AppDbContext dbContext)
    {
        _databaseContext = dbContext;
    }


    public IActionResult Adopt()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> adopt(AdoptionRequest userRequest)
    {
        if(ModelState.IsValid)
        {
            _databaseContext.adoptionRequests.Add(userRequest);
            await _databaseContext.SaveChangesAsync();
            RedirectToAction(nameof(Adopt)); //should redirect to dogs controller
        }
        return View(nameof(Adopt));
    }
}
