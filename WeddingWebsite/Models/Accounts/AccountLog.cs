using WeddingWebsite.Data;

namespace WeddingWebsite.Models.Accounts;

public record AccountLog(
    DateTime Date,
    Account AffectedUser,
    Account Actor,
    AccountLogType LogType,
    string Description
);