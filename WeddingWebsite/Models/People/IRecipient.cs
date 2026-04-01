namespace WeddingWebsite.Models.People;

public interface IRecipient
{
    Name Name { get; }
    string? Address { get; }
    string? BankDetails { get; }
}