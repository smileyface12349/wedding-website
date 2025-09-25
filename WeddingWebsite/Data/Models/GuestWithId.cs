using WeddingWebsite.Models;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Data.Models;

public record GuestWithId(string Id, Name Name, RsvpStatus RsvpStatus) : Guest(Name, RsvpStatus);