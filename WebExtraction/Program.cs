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
            var starsNode = document.DocumentNode.SelectSingleNode("//span[@class='bui-rating bui-rating--smaller']");
            Console.WriteLine(titleNode.GetDirectInnerText());
            Console.WriteLine(starsNode.Attributes["aria-label"].Value);
            Console.ReadLine();
        }
    }
}
