using WeddingWebsite.Models.Rsvp;

namespace WeddingWebsite.Models.ConfigInterfaces;

public interface IRsvpForm
{
    IEnumerable<RsvpQuestion> YesFormQuestions { get; }
    IEnumerable<RsvpQuestion> NoFormQuestions { get; }
}