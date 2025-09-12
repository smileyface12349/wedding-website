namespace WeddingWebsite.Models.Validation;

public record ValidationIssue(ValidationIssueSeverity Severity, string Message);