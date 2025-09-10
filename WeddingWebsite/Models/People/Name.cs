namespace WeddingWebsite.Models.People;

public record Name(string First, string Last)
{
    public string Full => $"{First} {Last}";

    public override string ToString() {
        return Full;
    }
}