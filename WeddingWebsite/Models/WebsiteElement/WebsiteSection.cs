namespace WeddingWebsite.Models.WebsiteElement;

/// <summary>
/// A section with a heading and content. This deliberately abstracts from how it is rendered.
/// </summary>
/// <param name="Heading">Text of high emphasis that appears before the content</param>
/// <param name="Content">Paragraphs of content appearing after the heading</param>
/// <param name="Media">Media which may appear anywhere from before the heading to after the content</param>
public record WebsiteSection (string? Heading, IEnumerable<string> Content, IWebsiteElement? Media = null)
{
    /// <summary>
    /// If you really need an image to be in a certain order, add the image in its own section.
    /// </summary>
    public WebsiteSection(IWebsiteElement media) : this(null, [], media) {}
    
    public WebsiteSection(string? heading, string? content, IWebsiteElement? media = null) 
        : this (heading, content == null ? [] : [content], media) {}
}