using System;

namespace WebExtraction
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string url = "https://www.booking.com/hotel/de/kempinskibristolberlin.en-gb.html?dcid=4;label=gen173nr-15CAsoO0IWa2VtcGluc2tpYnJpc3RvbGJlcmxpbkguYgVub3JlZmg7iAEBmAEuuAEEyAEE2AED6AEB;type=total;dist=0;auth_success=1;sb_price_type=total;sid=76794d5ed9a9673c09a746b2d3e1a5bd";
            IHotelDataScraper scraper = new HotelDataScraper(url);
            var hotelBristolBerlin = scraper.ScrapeHotelData();

            const string fileName = "hotel.json";
            IHotelDataFileWriter fileWriter = new HotelDataFileWriter();
            fileWriter.WriteHotelDataToFile(hotelBristolBerlin,fileName);
            
            Console.ReadLine();
        }
    }
}
