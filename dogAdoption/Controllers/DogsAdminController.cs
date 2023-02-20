using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using dogAdoption.Models;
using dogAdoption.Data;
using System.Threading.Tasks;

namespace dogAdoption.Controllers;

public class DogsAdminController : Controller
{
    
    private readonly AppDbContext _databaseContext;
    public DogsAdminController(AppDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IActionResult adminDog()
    {
        IEnumerable<Dog> dogs =  _databaseContext.dogs.ToList();
        return View(dogs);
    }


    [HttpGet]
    public IActionResult createDog()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> createDog(Dog dataInput)
    {
        if(ModelState.IsValid)
        {
            List<Dog> allDogs = await _databaseContext.dogs.ToListAsync();
            foreach(var dog in allDogs)
            {
                if(dog.Name == dataInput.Name)
                {
                    return BadRequest("Dog with same name exists in the database");
                }
            }
            var checkingIfDogExists = await _databaseContext.dogs.FindAsync(dataInput.Id);
            if(checkingIfDogExists == null)
            {

                _databaseContext.dogs.Add(dataInput);
                await _databaseContext.SaveChangesAsync();
                return RedirectToAction(nameof(adminDog));
            }
            return View(nameof(createDog));
        }
        return View(nameof(createDog));
    }


    public async Task<IActionResult> viewDog(int id)
    {
        if(id == 0 ) { return NotFound(); }
        var findDog = await _databaseContext.dogs.FindAsync(id);
        if (findDog == null)
        {
            return NotFound();
        }
        return View(findDog);
    }


    [HttpPost]
    public async Task<IActionResult> deleteDog(int? id)
    {
        if (id == 0 && id == null)
        {
            return BadRequest();
        }
        var findDog = await _databaseContext.dogs.FindAsync(id);
        if (findDog == null)
        {
            return NotFound();
        }
        _databaseContext.dogs.Remove(findDog);
        await _databaseContext.SaveChangesAsync();
        return RedirectToAction(nameof(adminDog));
    }


    [HttpGet]
    public async Task<IActionResult> updateDog(int id)
    {
        var dog = await _databaseContext.dogs.FindAsync(id);
        if(dog == null)
        {
            return BadRequest();
        }
        return View(dog);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> updateDog(Dog dogInput)
    {
        _databaseContext.Entry(dogInput).State = EntityState.Modified;
        await _databaseContext.SaveChangesAsync();
        return RedirectToAction(nameof(adminDog));

    }


    public ActionResult adoptedDogs()
    {
        var dogs = _databaseContext.dogs.ToList();
        IEnumerable<Dog> adoptedDogs = from  dog in dogs
                        where dog.adopted == true
                        select dog;
        return View(adoptedDogs);
    }

}
