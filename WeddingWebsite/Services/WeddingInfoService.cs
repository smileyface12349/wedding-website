using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using WeddingWebsite.Config.WeddingDetails;
using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Services;

[Authorize]
public class WeddingInfoService
{
    private IWeddingDetails weddingDetails = new SampleWeddingDetails();
    
    public IWeddingDetails GetWeddingDetails() {
        return weddingDetails;
    }

}