namespace WeddingWebsite.Models.WebsiteElement;

public record WeddingModal(string Label, IEnumerable<WebsiteSection> Content, string Title)
{
    public WeddingModal(string label, IEnumerable<WebsiteSection> content) :  this(label, content, label) {}
    
    public WeddingModal(string label, string content) : this (label, [new WebsiteSection(null, content)], label) {}
}