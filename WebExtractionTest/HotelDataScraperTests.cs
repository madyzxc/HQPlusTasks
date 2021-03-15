using NUnit.Framework;
using WebExtraction;
using WebExtraction.Model;

namespace WebExtractionTest
{
    [TestFixture]
    public class HotelDataScraperTests
    {
        private IHotelDataScraper _scraper;
        private Hotel _actualHotel;
        private const string Url = "https://www.booking.com/hotel/de/kempinskibristolberlin.en-gb.html?dcid=4;label=gen173nr-15CAsoO0IWa2VtcGluc2tpYnJpc3RvbGJlcmxpbkguYgVub3JlZmg7iAEBmAEuuAEEyAEE2AED6AEB;type=total;dist=0;auth_success=1;sb_price_type=total;sid=76794d5ed9a9673c09a746b2d3e1a5bd";

        [SetUp]
        public void SetUp()
        {
            _scraper = new HotelDataScraper(Url);
            _actualHotel = _scraper.ScrapeData();
        }
        
        [Test]
        public void ScrapeData_WhenCalled_ReturnsCorrectHotelTitle()
        {
            Assert.AreEqual("Hotel Bristol Berlin",_actualHotel.Name);
        }
        
        [Test]
        public void ScrapeData_WhenCalled_ReturnsCorrectHotelAddress()
        {
            Assert.AreEqual("Kurfürstendamm 27, Charlottenburg-Wilmersdorf, 10719 Berlin, Germany",_actualHotel.Address);
        }
        
        [Test]
        public void ScrapeData_WhenCalled_ReturnsCorrectReviewPoints()
        {
            Assert.AreEqual(8.3f,_actualHotel.ReviewPoints);
        }
        
        [Test]
        public void ScrapeData_WhenCalled_ReturnsCorrectNumberOfReviews()
        {
            Assert.AreEqual(3558,_actualHotel.NumberOfReviews);
        }
        
        
        
    }
}