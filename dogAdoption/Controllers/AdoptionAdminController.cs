using Microsoft.AspNetCore.Mvc;
using dogAdoption.Models;
using dogAdoption.Data;
using Microsoft.EntityFrameworkCore;

namespace dogAdoption.Controllers;

public class AdoptionAdminController : Controller
{

    private readonly AppDbContext _databaseContext;
    public AdoptionAdminController(AppDbContext appDbContext)
    {
        _databaseContext = appDbContext;
    }

    public async Task<IActionResult> AdoptionRequestsAdmin() //displays pending
    {
        var requests = await _databaseContext.adoptionRequests.ToListAsync();
        IEnumerable<AdoptionRequest> pendingRequests = from request in requests
                            where request.Accepted != true && request.Accepted != false
                            select request;
        return View(pendingRequests);
    }


    [HttpGet]
    public async Task<IActionResult> requestDetail(int? id)
    {
        if(id == 0){ return NotFound(); }
        var request = await _databaseContext.adoptionRequests.FindAsync(id);
        if (request == null)
        {
            return NotFound();
        }
        return View(request);
    }


    public async Task<IActionResult> AdoptionAcceptedRequests()
    {
        var requests = await _databaseContext.adoptionRequests.ToListAsync();
        IEnumerable<AdoptionRequest> accepted = from request in requests
                            where request.Accepted == true
                            select request;
        return View(accepted);
    }


    public IActionResult AdoptionDeclinedRequests()
    {
        var requests = _databaseContext.adoptionRequests.ToList();
        IEnumerable<AdoptionRequest> declined = from request in requests
                            where request.Accepted == false
                            select request;
        return View(declined);
    }


    [HttpPost]
    public async Task<IActionResult> acceptAdoption(int id)
    {
        if(id ==0 ){ return NotFound(); }
        var request = await _databaseContext.adoptionRequests.FindAsync(id);
        if (request == null)
        {
            return NotFound();
        }
        request.Accepted = true;
        // inform the client via email

        // change the dog to adopted true

        var ids = request.dog?.Id;
        var getDogWithSameId = await _databaseContext.dogs.FindAsync(ids);
        if(getDogWithSameId == null){ return BadRequest(); }
        getDogWithSameId.adopted = true;
        // request.dog.adopted = true;
        await _databaseContext.SaveChangesAsync();
        return RedirectToAction(nameof(AdoptionAcceptedRequests));
    }


    [HttpPost]
    public async Task<IActionResult> declineAdoption(int id)
    {
        if (id ==0 ){ return BadRequest(); }
        var request = await _databaseContext.adoptionRequests.FindAsync(id);
        if (request == null)
        {
            return NotFound();
        }
        request.Accepted = false;
        // inform the client via email
        await _databaseContext.SaveChangesAsync();
        return RedirectToAction(nameof(AdoptionDeclinedRequests));
    }


}
