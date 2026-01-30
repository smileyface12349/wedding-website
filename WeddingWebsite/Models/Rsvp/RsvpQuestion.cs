namespace WeddingWebsite.Models.Rsvp;

public record RsvpQuestion(
    string Title,
    string? Description,
    bool Required,
    RsvpQuestionType QuestionType
);