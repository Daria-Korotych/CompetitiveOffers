using System.Globalization;
using System.Net;
using Competitive_offers.Models;
using Competitive_offers.Models.OfferSubjectsModels;
using HtmlAgilityPack;

namespace Competitive_offers;

public static class GetOfferSubjects
{
    private static bool CheckNmtSubject(HtmlNode node)
    {
        return node.SelectSingleNode(".//div[contains(@class,'subject-name ef-3nm')]") != null;
    }

    private static bool CheckZnoSubject(HtmlNode node)
    {
        return node.SelectSingleNode(".//div[contains(@class,'subject-name ef-3')]") != null;
    }

    private static bool CheckForMotLetterNode(HtmlNode node)
    {
        return node.SelectSingleNode(".//div[contains(@class,'subject-name ef-100')]") != null;
    }

    private static bool CheckForProfTest(HtmlNode node)
    {
        return node.SelectSingleNode(".//div[contains(@class,'subject-name ef-20')]") != null;
    }
    public static OfferSubjects Info(HtmlNode offerDiv)
    {
        var offerSubjects = new OfferSubjects
        {
            Subjects = []
        };

        var subjectNodes = offerDiv.SelectNodes(".//div[@class='subject-wrapper']");

        offerSubjects.MotivationLetter = new MotivationLetter
        {
            Requirenments = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//div[@class='mlr_text']")?.InnerText.Trim()) ?? "N/A",
        };
        
        if (subjectNodes != null)
        {
            var culture = CultureInfo.InvariantCulture;
            
            foreach (var node in subjectNodes)
            {
                var subject = new Subject();
                if (CheckNmtSubject(node))
                {
                        subject.Name = WebUtility.HtmlDecode(node.SelectSingleNode(".//div[contains(@class,'subject-name ef-3nm')]")
                            .InnerText.Trim());
                }
                else if(CheckZnoSubject(node))
                {
                    subject.Name = WebUtility.HtmlDecode(node.SelectSingleNode(".//div[contains(@class,'subject-name ef-3')]")
                        .InnerText.Trim());
                }
                else if (CheckForProfTest(node))
                {
                    subject.Name = WebUtility.HtmlDecode(node.SelectSingleNode(".//div[contains(@class,'subject-name ef-20')]")
                        .InnerText.Trim());
                }

                if (CheckForMotLetterNode(node))
                {
                    offerSubjects.MotivationLetter.Coeficient =
                        double.Parse(node.SelectSingleNode(".//div[contains(@class,'coefficient')]").InnerText.Trim(),
                             culture);
                }
                else
                {
                    subject.Coefficient =
                        double.Parse(node.SelectSingleNode(".//div[contains(@class,'coefficient')]").InnerText.Trim(),
                            culture);
                    subject.MinScore = node.SelectSingleNode(".//div[contains(@class,'min-value')]")?.InnerText.Trim() ?? "N/A";
                    subject.Test = node.SelectSingleNode(".//div[contains(@class,'subject-name')]")?
                        .GetAttributeValue("title", "")?.Trim() ?? "N/A";
                    subject.IsSubjectToChoice = node.SelectSingleNode(".//div[contains(@class,'isChoosing')]") != null;
                    
                    offerSubjects.Subjects.Add(subject);
                }
            }
        }

        offerSubjects.Statistics = new Statistics
        {
            ApplicationsSubmitted = offerDiv.SelectSingleNode(".//div[contains(@class,'stats-field-t')]//div[@class='value']")?.InnerText.Trim() ?? "N/A",
            ApplicationsAccepted = offerDiv.SelectSingleNode(".//div[contains(@class,'stats-field-a')]//div[@class='value']")?.InnerText.Trim() ?? "N/A",
            BudgetApplications = offerDiv.SelectSingleNode(".//div[contains(@class,'stats-field-b')]//div[@class='value']")?.InnerText.Trim() ?? "N/A",
            AverageScore = offerDiv.SelectSingleNode(".//div[contains(@class,'stats-field-ka')]//div[@class='value']")?.InnerText.Trim() ?? "N/A",
            MinimumScore = offerDiv.SelectSingleNode(".//div[contains(@class,'stats-field-km')]//div[@class='value']")?.InnerText.Trim() ?? "N/A",
            MaximumScore = offerDiv.SelectSingleNode(".//div[contains(@class,'stats-field-kx')]//div[@class='value']")?.InnerText.Trim() ?? "N/A",
            RecommendedGeneral = offerDiv.SelectSingleNode(".//div[contains(@class,'stats-field-r')]//div[@class='value']")?.InnerText.Trim() ?? "N/A",
            TransferredToTheBudget = offerDiv.SelectSingleNode(".//div[contains(@class,'stats-field-ob')]//div[@class='value']")?.InnerText.Trim() ?? "N/A",
            MinimumRecommendedScore = offerDiv.SelectSingleNode(".//div[contains(@class,'stats-field-rm')]//div[@class='value']")?.InnerText.Trim() ?? "N/A",
            MinimumRecommendedScoreToTheBudget = offerDiv.SelectSingleNode(".//div[contains(@class,'stats-field-obm')]//div[@class='value']")?.InnerText.Trim() ?? "N/A"
        };
        
        return offerSubjects;
    }
}