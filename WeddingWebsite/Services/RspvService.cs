using Microsoft.AspNetCore.Authorization;

namespace WeddingWebsite.Services;

[Authorize (Roles = "ReceptionGuest")]
public class RspvService
{
    
}