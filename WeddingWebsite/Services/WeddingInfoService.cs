using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using WeddingWebsite.Models.WeddingDetails;

namespace WeddingWebsite.Services;

[Authorize]
public class WeddingInfoService
{
    private IWeddingDetails weddingDetails = new SampleWeddingDetails();
    
    public IWeddingDetails GetWeddingDetails() {
        return weddingDetails;
    }

}