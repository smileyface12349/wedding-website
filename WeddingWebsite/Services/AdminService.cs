using Microsoft.AspNetCore.Authorization;

namespace WeddingWebsite.Services;

[Authorize (Roles = "Admin")]
public class AdminService
{
    
}