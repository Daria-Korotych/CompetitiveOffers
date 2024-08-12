using HtmlAgilityPack;
using OpenQA.Selenium;

namespace Competitive_offers.PageProcessing;

public static class HtmlPageProcessing
{
    public static HtmlDocument? HtmlPageSource(IWebDriver driver)
    {
        try
        {
            var pageSource = driver.PageSource;
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(pageSource);
            return htmlDoc;
        }
        catch (Exception e)
        {
            Console.WriteLine($"The exception occured in getting html page source:\n{e}");
            return null;
        }
    }

    public static HtmlNode? GetUniversities(HtmlDocument? htmlDoc)
    {
        try
        {
            return htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"universities\"]");
        }
        catch (Exception e)
        {
            Console.WriteLine($"The exception occured in getting all universities div:\n{e}");
            return null;
        }
    }

    public static HtmlNodeCollection? GetUniversity(HtmlNode targetDiv)
    {
        return targetDiv.SelectNodes(".//div[@class='university']");
    }
}