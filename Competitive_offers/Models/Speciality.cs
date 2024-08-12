namespace Competitive_offers.Models;

public class Speciality
{
    public string Code { get; set; } = null!;
    public string? Name { get; set; } = null!;
    public List<UniversityNode>? Offers { get; set; }
}