using System.Net;
using HtmlAgilityPack;

namespace Competitive_offers;
using Models;

public static class GetOffer
{
    public static Offer GetOfferInfo(HtmlNode offerDiv)
    {
        var offer = new Offer
        {
            NameOfOffer = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-university-specialities-name'][2]//dd")?.InnerText)?.Trim() ?? "N/A",
            BidCode = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-university-specialities'][1]//dd")?
                .InnerText.Trim()) ?? "N/A",
            EducationalProgram = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-study-programs']//dd")?
                .InnerText.Trim()) ?? "N/A",
            Faculty = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-university-facultet-name']//dd")?
                .InnerText)?.Trim() ?? "N/A",
            FormOfStudy = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-education-form-name']//dd")?
                .InnerText.Trim()) ?? "N/A",
            CourseOfEnrolment = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-course-name']//dd")?
                .InnerText.Trim()) ?? "N/A",
            TypeOfOffer = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-offer-type-name']//dd")?
                .InnerText.Trim()) ?? "N/A",
            DurationOfStudy = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-education-term']//dd")?
                .InnerText.Trim()) ?? "N/A",
            ApplicationDeadline = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-request-term']//dd")?
                .InnerText.Trim()) ?? "N/A",
            LicenceVolume = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-order-license']//dd")?
                .InnerText.Trim()) ?? "N/A",
            StateOrderVolume = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-order-budget']//dd")?
                .InnerText.Trim()) ?? "N/A",
            RegionalCoefficient = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-regional-coeff']//dd")?
                .InnerText.Trim()) ?? "N/A",
            TuitionFeePerYear = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-education-price']//dd")?
                .InnerText.Trim()) ?? "N/A",
            TotalCostForFullTerm = WebUtility.HtmlDecode(offerDiv.SelectSingleNode(".//dl[@class='row offer-education-all-term-price']//dd")?
                .InnerText.Trim()) ?? "N/A",
            
            OfferSubjects = GetOfferSubjects.Info(offerDiv)
        };
        return offer;
    }
}