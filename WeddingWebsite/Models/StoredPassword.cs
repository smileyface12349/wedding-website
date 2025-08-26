namespace WeddingWebsite.Models;

public record StoredPassword(
    string Hash,
    string Salt
);