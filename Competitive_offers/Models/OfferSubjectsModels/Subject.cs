namespace Competitive_offers.Models.OfferSubjectsModels;

public class Subject
{
    public string Name { get; set; }
    public string Test { get; set; }
    public double Coefficient { get; set; }
    public string MinScore { get; set; }
    public bool IsSubjectToChoice { get; set; }
}