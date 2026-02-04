using WeddingWebsite.Models.Rsvp;

namespace WeddingWebsite.Models.ConfigInterfaces;

public interface IRsvpForm
{
    RsvpQuestions YesQuestions { get; }
    RsvpQuestions NoQuestions { get; }
}