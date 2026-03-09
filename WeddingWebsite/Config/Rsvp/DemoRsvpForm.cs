using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Rsvp;

namespace WeddingWebsite.Config.Rsvp;

public class DemoRsvpForm : IRsvpForm
{
    public RsvpQuestions YesQuestions => new RsvpQuestions(
        [
            new RsvpQuestion(
                Title: "Do you have any dietary requirements?",
                Description: null,
                Required: false,
                QuestionType: new RsvpQuestionType.MultiSelect(
                    Options:
                    [
                        new MultiSelectOption("Vegetarian", new RsvpDataColumn(1, "V")),
                        new MultiSelectOption("Vegan", new RsvpDataColumn(2, "VG")),
                        new MultiSelectOption("Gluten free", new RsvpDataColumn(3, "GF")),
                        new MultiSelectOption("Dairy free", new RsvpDataColumn(4, "DF")),
                        new MultiSelectOption("Nut allergy", new RsvpDataColumn(5, "NUT")),
                        new MultiSelectOption("I have no dietary requirements", new RsvpDataColumn(0, null))
                    ],
                    OtherField: new RsvpQuestionType.FreeText(new RsvpDataColumn(6, "Other Dietary Requirements"), 100, "Additional dietary requirements")
                )
            ),
            new RsvpQuestion(
                Title: "What would you like for your main course?",
                Description: "Please choose the option that most closely fits your dietary requirements. If neither of the options work, we will adapt your meal accordingly.",
                Required: true,
                QuestionType: new RsvpQuestionType.Select(
                    DataColumn: new RsvpDataColumn(7, "Main Course"),
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
                Description: "If not, please leave this blank.",
                Required: false,
                QuestionType: new RsvpQuestionType.FreeText(new RsvpDataColumn(8, "Special Requests"), 200, "Accessible parking, seating plan, large print order of service etc." )
            )
        ],
        Validator: data =>
        {
            IList<string> issues = [];
            
            // If they have selected "I have no dietary requirements", they shouldn't have selected any other options.
            if (data[0] == "Y" && (data[1] == "Y" || data[2] == "Y" || data[3] == "Y" || data[4] == "Y" || data[5] == "Y" || !string.IsNullOrEmpty(data[6])))
            {
                issues.Add("You have selected both 'I have no dietary requirements' and some dietary requirements. If you have no dietary requirements, please don't select any other options.");
            }
            
            // If they are a vegan, select vegetarian and dairy free too, but don't output any error.
            if (data[2] == "Y")
            {
                data[1] = "Y";
                data[4] = "Y";
            }
            
            // Don't allow selecting meat option if they are a vegetarian.
            if (data[1] == "Y" && data[7] != null && data[7]!.Contains("Chicken"))
            {
                issues.Add("You have selected vegetarian and chicken. Please choose the vegetarian option if you are a vegetarian.");
            }

            return issues;
        }
    );
    
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
    
    public bool LongAttendanceResponses => false;
}