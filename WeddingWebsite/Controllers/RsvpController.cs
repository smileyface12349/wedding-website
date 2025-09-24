using Microsoft.AspNetCore.Mvc;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Services;

namespace WeddingWebsite.Controllers;

[ApiController]
[Route("/")]
public class RsvpController (IRsvpService rsvpService) : Controller
{
    [HttpGet("/api/guests")]
    public async Task<IEnumerable<GuestResponse>> GetGuests()
    {
        return rsvpService.GetOwnGuests(HttpContext.User);
    }
    

    
}