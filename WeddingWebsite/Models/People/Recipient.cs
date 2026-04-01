namespace WeddingWebsite.Models.People;

public record Recipient(
    Name Name,
    string? Address,
    string? BankDetails
);