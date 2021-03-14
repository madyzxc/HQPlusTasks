using System;
using HtmlAgilityPack;

namespace WebExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "https://www.booking.com/hotel/de/kempinskibristolberlin.en-gb.html?dcid=4;label=gen173nr-15CAsoO0IWa2VtcGluc2tpYnJpc3RvbGJlcmxpbkguYgVub3JlZmg7iAEBmAEuuAEEyAEE2AED6AEB;type=total;dist=0;auth_success=1;sb_price_type=total;sid=76794d5ed9a9673c09a746b2d3e1a5bd";
            var web = new HtmlWeb();
            var document = web.Load(url);
            var titleNode = document.DocumentNode.SelectSingleNode("//h2[@class='hp__hotel-name']");
            var addressNode = document.DocumentNode.SelectSingleNode("//p[@id='showMap2']/span");
            var reviewPointsNode = document.DocumentNode.SelectSingleNode("//div[@class='bui-review-score__badge']");
            var numberOfReviewsNode = document.DocumentNode.SelectSingleNode("//div[@class='bui-review-score__text']");
            var descriptionNode = document.DocumentNode.SelectSingleNode("//div[@id='property_description_content']");
            var starsNode = document.DocumentNode.SelectSingleNode("//span[@class='bui-rating bui-rating--smaller']");
            Console.WriteLine(titleNode.GetDirectInnerText().Trim());
            Console.WriteLine(addressNode.GetDirectInnerText().Trim());
            Console.WriteLine(reviewPointsNode.GetDirectInnerText().Trim());
            Console.WriteLine(numberOfReviewsNode.GetDirectInnerText().Trim());
            Console.WriteLine(descriptionNode.InnerText.Trim());
            Console.WriteLine(starsNode.Attributes["aria-label"].Value);
            Console.ReadLine();
        }
    }
}
