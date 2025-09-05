namespace WeddingWebsite.Models.WebsiteElement;

public record WeddingModal(string Label, string HtmlContent, string Title)
{
    public WeddingModal(string label, string htmlContent) :  this(label, htmlContent, label) {}
}