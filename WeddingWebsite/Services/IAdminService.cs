namespace WeddingWebsite.Services;

public interface IAdminService
{
    void AddGuestToAccount(string userId, string firstName, string lastName);
}