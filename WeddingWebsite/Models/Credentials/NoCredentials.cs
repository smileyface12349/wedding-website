namespace WeddingWebsite.Models.Credentials;

/// <summary>
/// Default credentials file with no credentials. If you try to access something requiring an API key, a
/// NotImplementedException will be thrown.
/// However, you do not have to fill in all the credentials if you do not use all the functionality.
/// This is provided so you can get the code to compile without all the credentials.
/// </summary>

public class NoCredentials : IGoogleMapsApiKey
{
    public string GoogleMaps => throw new NotImplementedException();
}