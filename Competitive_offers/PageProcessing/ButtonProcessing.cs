using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Competitive_offers.PageProcessing;

public static class ButtonProcessing
{
    public static void UniversityButtons(IWebDriver driver)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        var buttons = driver.FindElements(By.CssSelector(".university-title-row"));
        var i = 0;
        foreach (var button in buttons)
        {
            i++;
            try
            {
                button.Click();
                wait.Until(webDriver => webDriver.FindElement(By.XPath(".//div[@class='university']")).Displayed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to click button: {ex.Message}\ni: {i}");
            }
        }
    }

    public static bool OfferMessage(IWebDriver driver)
    {
        var noOffersMessage = driver.FindElements(By.CssSelector(".modal.fade.show"));
        if (noOffersMessage.Any())
        {
            var closeButton = driver.FindElement(By.CssSelector(".modal-header .close"));
            closeButton.Click();
            
            return true;
        }

        return false;
    }
}