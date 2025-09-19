namespace WeddingWebsite.Models.WebsiteElement;

public record LinkButton(string Text, string Link) : IWebsiteElement
{
    public string GetHtml(string className = "") {
        return $"<a href=\"{Link}\" class=\"{className}\">{Text}</a>";
    }
}