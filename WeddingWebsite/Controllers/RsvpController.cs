using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingWebsite.Data.Enums;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Services;

namespace WeddingWebsite.Controllers;

[ApiController]
[Route("/")]
[Authorize]
public class RsvpController (IRsvpService rsvpService) : Controller
{
    [HttpGet("/api/guests")]
    public async Task<IEnumerable<GuestResponse>> GetGuests()
    {
        var guest = rsvpService.GetOwnGuests(HttpContext.User);
        return guest.Select(g => new GuestResponse(g.Id, g.Name.First, g.Name.Last, g.RsvpStatus.ToDatabaseInteger()));
    }
    

    
}