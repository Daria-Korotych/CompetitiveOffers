using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Competitive_offers.Models;

namespace Competitive_offers;

static class Program
{
    private static Root _root = new()
    {
        Bachelor = new List<BasisInfo>()
    };

    static void Main()
    {
        Dictionary<string, string>? specInfo;
        var fileName = "C:\\Users\\darya\\RiderProjects\\Competitive_offers\\Competitive_offers\\Specialities.json";
        
        using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            specInfo = JsonSerializer.Deserialize<Dictionary<string, string>>(fileStream);
        }
        
        foreach (var edb in InfoForUrl.EducationBase)
        {
            var basis = new BasisInfo()
            {
                Name = edb.Value,
                Info = new Dictionary<string, Speciality>()
            };
            var specialities = new List<Speciality>();
            foreach (var spec in InfoForUrl.Specialities)
            {
                var speciality = new Speciality()
                {
                    Code = spec,
                    Name = specInfo?[spec],
                    Offers = new List<UniversityNode>()
                };
                    
                var url = $"https://vstup.edbo.gov.ua/offers/?qualification=1&education_base={edb.Key}&speciality={spec}";
                //var url = $"https://vstup2023.edbo.gov.ua/offers/?qualification=1&education_base={edb.Key}&speciality={spec}";
                    
                var universities = UniversityProcessing.GetUniversitiesOffers(url);
                speciality.Offers = universities;
                specialities.Add(speciality);
            }
            
            var specsNode = specialities.ToDictionary(x => x.Code, x => x);
            basis.Info = specsNode;
            _root.Bachelor.Add(basis);
        }
        
        var outputDirectory = "C:\\Users\\darya\\RiderProjects\\Competitive_offers\\Competitive_offers";
        var fileJson = Path.Combine(outputDirectory, "Bachelor.json");
        
        var jsonString = JsonSerializer.Serialize(_root, new JsonSerializerOptions 
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        });
        
        File.WriteAllText(fileJson, jsonString);
    }
}