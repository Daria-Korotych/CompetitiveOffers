using Competitive_offers.Models.OfferSubjectsModels;

namespace Competitive_offers.Models;

public class OfferSubjects
{
    public List<Subject> Subjects { get; set; } = null!;
    public MotivationLetter MotivationLetter { get; set; } = null!;
    public Statistics Statistics { get; set; } = null!;
}