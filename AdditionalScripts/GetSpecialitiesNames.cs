using System.Net;
using Competitive_offers;
using Competitive_offers.PageProcessing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AdditionalScripts;

static class Specialities
{
    public static Dictionary<string, string>? GetNames()
    {
        IWebDriver driver = new ChromeDriver();
        var url = "https://vstup.edbo.gov.ua/offers/";
        Dictionary<string, string> specialities = new ();

        try
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(4000);
            
            var htmlDoc = HtmlPageProcessing.HtmlPageSource(driver);
            
            var form = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"offers-search-speciality\"]");
            var options = form.SelectNodes(".//option");

            foreach (var option in options)
            {
                var source = WebUtility.HtmlDecode(option.InnerText);
                
                if (source.Length > 0)
                {
                    var code = option.GetAttributeValue("value", "");
                    var name = string.Join(" ", source.Split(" ").Skip(1));
                    if (code.Contains('-'))
                    {
                        var codeParent = String.Join("", code.Take(3));
                        name = specialities[codeParent] + " " + name;
                    }
                    specialities.Add(code, name);
                }
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

        return specialities;
    }
    
    
}