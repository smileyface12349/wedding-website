namespace WeddingWebsite.Models.WebsiteConfig;

public enum MeetWeddingPartyDisplay
{
    /// <summary>
    /// Displays boxes in two separate columns. This leaves lots of space for introductions. If you're not doing an
    /// introduction, consider switching to <see cref="Grid"/> display mode.
    /// </summary>
    TwoColumns,
    
    /// <summary>
    /// Displays boxes in two separate rows. This is useful if you haven't got that much stuff to say about each person
    /// (e.g. if you're just doing a fun fact, even just name, role and picture), and therefore using columns leaves
    /// lots of empty space. The boxes will be as small as they need to be to fit the content, but will sometimes wrap
    /// onto multiple lines if you've got a big wedding party.
    /// </summary>
    TwoRows,
    
    /// <summary>
    /// An array of smaller boxes arranged in a grid pattern. This is quite similar to TwoRows, but the boxes will just
    /// display sequentially with no divider. The Left side displays first, then the right side. The boxes will be
    /// approximately fixed size, and it will use as much space as it needs.
    /// </summary>
    Grid,
    
    /// <summary>
    /// A more compact view that puts the introductions into text messages.
    /// </summary>
    Chat
}