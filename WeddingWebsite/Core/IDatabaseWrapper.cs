using WeddingWebsite.Models;

namespace WeddingWebsite.Core;

/// <summary>
/// This exists to make it easy to swap between databases. As a result, not many operations are supported.
/// Consider carefully if functionality is really needed before adding it. Always prefer an existing slower method over
/// adding new functionality that relies on implementation details.
/// 
/// You should not assume that any authentication or authorisation is done, unless specified otherwise.
/// </summary>

public interface IDatabaseWrapper
{

}