using Microsoft.AspNetCore.Components;
using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Config.Strings;

/// <summary>
/// Standard English, with slight adaptations for American users.
/// </summary>
public class StandardAmericanEnglish : StandardBritishEnglish, IStringProvider
{
    public override string CurrencySymbol => "$";
}