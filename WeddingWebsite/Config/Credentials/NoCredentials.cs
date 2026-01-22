using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Config.Credentials;

/// <summary>
/// Implementation with no credentials, designed to fail gracefully.
/// If you want to use any restricted functionality, create your own implementation of ICredentials.
/// </summary>

public class NoCredentials : ICredentials
{
    public string GoogleMaps => "";
}