namespace WeddingWebsite.Models.People;

public record ContactOptions(
    IEnumerable<ContactReason> Reasons,
    IEnumerable<IContactOption> Methods
);