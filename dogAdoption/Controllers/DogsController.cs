using Microsoft.AspNetCore.Mvc;
using dogAdoption.Models;
using dogAdoption.Data;


namespace dogAdoption.Controllers;

public class DogsController : Controller
{
    private readonly AppDbContext _dbContext;
    public DogsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult DogsLists()
    {   
        IEnumerable<Dog> dogs =  _dbContext.dogs.ToList();
        IEnumerable<Dog> availableDogs = from dog in dogs
                                    where dog.adopted != true
                                    select dog;
        return View(availableDogs);
    }


    public async Task<IActionResult> DogDetails(int id)
    {
        var singleDog = await _dbContext.dogs.FindAsync(id);
        if (singleDog == null)
        {
            return NotFound();
        }
        return View(singleDog);
    }


    public IActionResult Search()
    {
        return View();
    }
}
