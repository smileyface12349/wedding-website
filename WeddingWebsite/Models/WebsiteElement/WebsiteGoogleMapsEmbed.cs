namespace WeddingWebsite.Models.WebsiteElement;

public record WebsiteGoogleMapsEmbed(Location Location): IWebsiteElement
{
    public string GetHtml(string className = "") {
        throw new NotImplementedException();
    }
}