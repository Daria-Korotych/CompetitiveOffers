namespace Competitive_offers.Models;

public class Offer
{
    public string NameOfOffer { get; set; } = null!;
    public string BidCode { get; set; } = null!;
    public string EducationalProgram { get; set; } = null!;
    public string Faculty { get; set; } = null!;
    public string FormOfStudy { get; set; } = null!;
    public string CourseOfEnrolment { get; set; } = null!;
    public string TypeOfOffer { get; set; } = null!;
    public string DurationOfStudy { get; set; } = null!;
    public string ApplicationDeadline { get; set; } = null!;
    public string LicenceVolume { get; set; } = null!;
    public string StateOrderVolume { get; set; } = null!;
    public string RegionalCoefficient { get; set; } = null!;
    public string TuitionFeePerYear { get; set; } = null!;
    public string TotalCostForFullTerm { get; set; } = null!;
    public OfferSubjects OfferSubjects { get; set; }= null!;
}