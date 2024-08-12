namespace Competitive_offers.Models.OfferSubjectsModels;

public class Statistics
{
    public string ApplicationsSubmitted { get; set; }  = null!;
    public string ApplicationsAccepted { get; set; }  = null!;
    public string BudgetApplications { get; set; } = null!;
    public string AverageScore { get; set; } = null!;
    public string MinimumScore { get; set; } = null!;
    public string MaximumScore { get; set; } = null!;
    public string RecommendedGeneral { get; set; } = null!;
    public string TransferredToTheBudget { get; set; } = null!;
    public string MinimumRecommendedScore { get; set; } = null!;
    public string MinimumRecommendedScoreToTheBudget { get; set; } = null!;
}