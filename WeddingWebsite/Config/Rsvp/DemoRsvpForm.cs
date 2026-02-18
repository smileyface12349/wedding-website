using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Rsvp;

namespace WeddingWebsite.Config.Rsvp;

public class DemoRsvpForm : IRsvpForm
{
    public RsvpQuestions YesQuestions => new RsvpQuestions(
    [
        new RsvpQuestion(
            Title: "Do you have any dietary requirements?",
            Description: "If not, please leave this field blank.",
            Required: false,
            QuestionType: new RsvpQuestionType.MultiSelect(
                Options:
                [
                    new MultiSelectOption("Vegetarian", new RsvpDataColumn(2, "V")),
                    new MultiSelectOption("Vegan", new RsvpDataColumn(3, "VG")),
                    new MultiSelectOption("Gluten-Free", new RsvpDataColumn(4, "GF")),
                    new MultiSelectOption("Dairy-Free", new RsvpDataColumn(5, "DF")),
                    new MultiSelectOption("Nut Allergy", new RsvpDataColumn(6, "NUT"))
                ],
                OtherField: new RsvpQuestionType.FreeText(new RsvpDataColumn(1, "Other Dietary Requirements"), 100, "Additional dietary requirements")
            )
        ),
        new RsvpQuestion(
            Title: "What would you like for your main course?",
            Description: null,
            Required: true,
            QuestionType: new RsvpQuestionType.Select(
                DataColumn: new RsvpDataColumn(7, "MainCourse"),
                Options:
                [
                    "Roast Chicken",
                    "Veggie Lasagne"
                ],
                OtherField: null
            )
        ),
        new RsvpQuestion(
            Title: "Is there anything else we can do to accommodate you on the day?",
            Description: null,
            Required: false,
            QuestionType: new RsvpQuestionType.FreeText(new RsvpDataColumn(8, "Special Requests"), 200)
        )
    ]);
    
    public RsvpQuestions NoQuestions => new RsvpQuestions(
    [
        new RsvpQuestion(
            Title: "We're sorry you can't make it! If you'd like to leave a message, you can do so below.",
            Description: "This question is optional. If you don't want to leave a message, just press submit.",
            Required: false,
            QuestionType: new RsvpQuestionType.FreeText(new RsvpDataColumn(1, "Reason"), 300)
        )
    ]);

    public DateTime? Deadline => null;
}