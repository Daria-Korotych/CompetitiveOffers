namespace Competitive_offers.Models;

public class UniversityNode
{
    public string UniversityId { get; set; } = null!;
    public string NameOfUniversity { get; set; } = null!;
    public List<Offer> OfferInfo { get; set; } = null!;
}