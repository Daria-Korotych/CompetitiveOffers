using Competitive_offers.Models;
using Competitive_offers.PageProcessing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Competitive_offers;

public static class UniversityProcessing
{
    public static List<UniversityNode> GetUniversitiesOffers(string url)
    {
        var driver = new ChromeDriver();
        var allUniversities = new List<UniversityNode>();

        try
        {
            driver.Navigate().GoToUrl(url);
            
            Thread.Sleep(4000); 
            
            if (ButtonProcessing.OfferMessage(driver))
            {
                return allUniversities;
            }
            
            ButtonProcessing.UniversityButtons(driver);

            var htmlDoc = HtmlPageProcessing.HtmlPageSource(driver);
            
            var targetDiv = HtmlPageProcessing.GetUniversities(htmlDoc);

            if (targetDiv != null)
            {
                var universityDivs = HtmlPageProcessing.GetUniversity(targetDiv);
                
                foreach (var universityDiv in universityDivs!)
                {
                    var dataUniversity = universityDiv.GetAttributeValue("data-university", "");
                    var offersDivs = universityDiv.SelectNodes(".//div[@class='offer']");
                    var universityNode = new UniversityNode
                    {
                        UniversityId = dataUniversity,
                        NameOfUniversity = universityDiv.SelectSingleNode(".//div[@class='university-title']")?.InnerText.Trim() ?? "N/A",
                        OfferInfo = new List<Offer>()
                    };

                    //universities often have the names like "6944Відокремлений структурний підрозділ..."
                    if (universityNode.NameOfUniversity.Contains(dataUniversity))
                    {
                        universityNode.NameOfUniversity = universityNode.NameOfUniversity.Replace(dataUniversity, "");
                    }
                    
                    if (offersDivs != null)
                    {
                        foreach (var offerDiv in offersDivs)
                        {
                            var offer = GetOffer.GetOfferInfo(offerDiv);
                            universityNode.OfferInfo.Add(offer);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Offers div not found for university: " + dataUniversity);
                    }
                    
                    allUniversities.Add(universityNode);
                }
            }
            else
            {
                Console.WriteLine("Target div not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            driver.Quit();
        }

        return allUniversities;
    }
}