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
            _actualHotel = _scraper.ScrapeHotelData();
        }
        
        [Test]
        public void ScrapeData_WhenCalled_ReturnsCorrectHotelTitle()
        {
            Assert.That(_actualHotel.Name,Is.EqualTo("Hotel Bristol Berlin"));
        }
        
        [Test]
        public void ScrapeData_WhenCalled_ReturnsCorrectHotelAddress()
        {
            Assert.That(_actualHotel.Address,Is.EqualTo("Kurfürstendamm 27, Charlottenburg-Wilmersdorf, 10719 Berlin, Germany"));
        }
        
        [Test]
        public void ScrapeData_WhenCalled_ReturnsCorrectReviewPoints()
        {
            Assert.That(_actualHotel.ReviewPoints,Is.EqualTo(8.3f));
        }
        
        [Test]
        public void ScrapeData_WhenCalled_ReturnsCorrectNumberOfReviews()
        {
            Assert.That(_actualHotel.NumberOfReviews,Is.GreaterThan(3550));
        }
    }
}