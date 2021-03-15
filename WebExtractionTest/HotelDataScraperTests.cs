using NUnit.Framework;
using WebExtraction;
using WebExtraction.Model;

namespace WebExtractionTest
{
    [TestFixture]
    public class HotelDataScraperTests
    {
        private IHotelDataScraper _scraper;
        private const string Url = "https://www.booking.com/hotel/de/kempinskibristolberlin.en-gb.html?dcid=4;label=gen173nr-15CAsoO0IWa2VtcGluc2tpYnJpc3RvbGJlcmxpbkguYgVub3JlZmg7iAEBmAEuuAEEyAEE2AED6AEB;type=total;dist=0;auth_success=1;sb_price_type=total;sid=76794d5ed9a9673c09a746b2d3e1a5bd";

        [SetUp]
        public void SetUp()
        {
            _scraper = new HotelDataScraper(Url);
        }
        
        [Test]
        public void ScrapeData_WhenCalled_ReturnsCorrectHotelTitle()
        {
            var actualHotel = _scraper.ScrapeData();
            Assert.AreEqual("Hotel Bristol Berlin",actualHotel.Name);
        }
        [Test]
        public void ScrapeData_WhenCalled_ReturnsCorrectHotelAddress()
        {
            var actualHotel = _scraper.ScrapeData();
            Assert.AreEqual("Kurfürstendamm 27, Charlottenburg-Wilmersdorf, 10719 Berlin, Germany",actualHotel.Address);
        }
        
    }
}