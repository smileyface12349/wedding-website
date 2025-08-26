namespace WeddingWebsite.Models.WebsiteElement;

public class WebsiteVideo(string url) : IWebsiteElement
{
    private string Url { get; } = url;

    public string GetHtml()
    {
        throw new NotImplementedException("This will be implemented once it is needed.");
    }
}