using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HtmlAgilityPack;
using WebExtraction.Model;


namespace WebExtraction
{
    public class HotelDataScraper : IHotelDataScraper
    {
        private readonly HtmlDocument _document;
        private const string TitleXpath = "//h2[@class='hp__hotel-name']";
        private const string AddressXpath = "//p[@id='showMap2']/span";
        private const string ReviewPointsXpath = "//div[@class='bui-review-score__badge']";
        private const string NumberOfReviewsXpath = "//div[@class='bui-review-score__text']";
        private const string DescriptionXpath = "//div[@id='property_description_content']";
        private const string RatingXpath = "//span[@class='bui-rating bui-rating--smaller']";
        private const string RoomInfoXpath = "//div[@class='room-info']/a";

        public HotelDataScraper(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            var web = new HtmlWeb();
            _document = web.Load(url);
        }
        public Hotel ScrapeHotelData()
        {
            var hotel = new Hotel();
            hotel.Name = GetHotelTitle(TitleXpath);
            hotel.Address = GetHotelAddress(AddressXpath);
            hotel.ReviewPoints = GetHotelReviewPoints(ReviewPointsXpath);
            hotel.NumberOfReviews = GetNumberOfReviews(NumberOfReviewsXpath);
            hotel.Description = GetHotelDescription(DescriptionXpath);
            hotel.Classification = GetHotelClassification(RatingXpath);
            hotel.RoomCategories = GetRoomCategories(RoomInfoXpath);
            return hotel;
        }
        private IEnumerable<string> GetRoomCategories(string xpath)
        {
            if (string.IsNullOrWhiteSpace(xpath)) throw new ArgumentNullException(nameof(xpath));
            var roomTypeNodes = _document.DocumentNode.SelectNodes(xpath);
            if (roomTypeNodes == null)
            {
                throw new ArgumentNullException("Check Room Type XPath");
            }

            return roomTypeNodes.Select(roomType => roomType.InnerText.Trim()).ToList();
        }
        private Classification GetHotelClassification(string xpath)
        {
            if (string.IsNullOrWhiteSpace(xpath)) throw new ArgumentNullException(nameof(xpath)); 
            var starsNode = _document.DocumentNode.SelectSingleNode(xpath);
            if (starsNode == null)
            {
                throw new ArgumentNullException("Check Classificaton / Stars XPath");
            }
            return (Classification) int.Parse(starsNode.Attributes["aria-label"].Value.Substring(0,1));
        }
        private string GetHotelDescription(string xpath)
        {
            if (string.IsNullOrWhiteSpace(xpath)) throw new ArgumentNullException(nameof(xpath));
            var descriptionNode = _document.DocumentNode.SelectSingleNode(xpath);
            return descriptionNode.InnerText.Trim();
        }
        private int GetNumberOfReviews(string xpath)
        {
            if (string.IsNullOrWhiteSpace(xpath)) throw new ArgumentNullException(nameof(xpath));
            var numberOfReviewsNode = _document.DocumentNode.SelectSingleNode(xpath);
            var value = numberOfReviewsNode.InnerText.Trim().Replace(" reviews", "");
            return int.Parse(value, NumberStyles.AllowThousands);
        }
        private float GetHotelReviewPoints(string xpath)
        {
            if (string.IsNullOrWhiteSpace(xpath)) throw new ArgumentNullException(nameof(xpath));
            var reviewPointsNode = _document.DocumentNode.SelectSingleNode(xpath);
            return float.Parse(reviewPointsNode.InnerText.Trim());
        }
        private string GetHotelAddress(string xpath)
        {
            if (string.IsNullOrWhiteSpace(xpath)) throw new ArgumentNullException(nameof(xpath));
            var addressNode = _document.DocumentNode.SelectSingleNode(xpath);
            return addressNode.GetDirectInnerText().Trim();
        }
        private string GetHotelTitle(string xpath)
        {
            if (string.IsNullOrWhiteSpace(xpath)) throw new ArgumentNullException(nameof(xpath));
            var titleNode = _document.DocumentNode.SelectSingleNode(xpath);
            return titleNode.GetDirectInnerText().Trim();
        }
    }
}