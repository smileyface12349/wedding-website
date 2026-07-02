using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models.Accounts;

public record GuestWithTable(
    string Id, 
    Name Name,
    RsvpStatus RsvpStatus,
    SeatingPlanTable? Table
) : GuestWithId(Id, Name, RsvpStatus);