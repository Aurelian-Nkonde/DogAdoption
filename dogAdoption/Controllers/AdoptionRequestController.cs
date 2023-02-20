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


    public async Task<IActionResult> Adopt(int? id)
    {
        // asking  if the user is sure on adopting a dog
        var dog = await _databaseContext.dogs.FindAsync(id);
        if(dog == null){ return NotFound(); }
        return View();
    }


    [HttpPost]
    public async Task<ActionResult>  Adopt([FromForm] AdoptionRequest request)
    {
        if(ModelState.IsValid)
        {
            await _databaseContext.adoptionRequests.AddAsync(request);
            await _databaseContext.SaveChangesAsync();
            return RedirectToAction("DogsLists", "Dogs");
        }
        return View();
    }
}
