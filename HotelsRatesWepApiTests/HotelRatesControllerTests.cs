using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelsRatesWepApi;
using HotelsRatesWepApi.Controllers;
using HotelsRatesWepApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace HotelsRatesWepApiTests
{
    public class HotelRatesControllerTests
    {
        private HotelRatesController _controller;
        [SetUp]
        public void Setup()
        {
            _controller = new HotelRatesController(new Logger<HotelsRatesWepApi.Controllers.HotelRatesController>(new LoggerFactory()));
        }

        [Test]
        public void Get_NotPassedParameters_ReturnsListOfHotels()
        {
            var result = _controller.Get();
            var actionResult = result as OkObjectResult;
            var contentResult = actionResult.Value as IEnumerable<Hotel>;
            Assert.That(contentResult.Count(), Is.EqualTo(2));
            var hotelid = (new List<HotelsRatesWepApi.Models.Hotel>(contentResult)[0]).HotelId;
            Assert.That(hotelid, Is.EqualTo(7294));

        }
        
        [Test]
        [TestCase(7294, "Kempinski Bristol Berlin")]
        [TestCase(8759, "NU Hotel am Kudamm Berlin")]
        public void Get_PassedHotelIDParameters_ReturnsHotelData(int hotelId,string expectedHotelName)
        {
            var result = _controller.Get(hotelId);
            var actionResult = result as OkObjectResult;
            var contentResult = actionResult.Value as IEnumerable<Hotel>;
            Assert.That(contentResult.Count(), Is.EqualTo(1));
            var hotelName = (new List<HotelsRatesWepApi.Models.Hotel>(contentResult)[0]).Name;
            Assert.That(hotelName, Is.EqualTo(expectedHotelName).IgnoreCase);
        }

        [Test]
        [TestCase(7294,"2016-03-15")]
        [TestCase(8759, "2016-03-15")]

        public void Get_PassedParametersHotelIDAndDate_ReturnsListOfHotelRates(int hotelID,DateTime date)
        {
            var result = _controller.Get(hotelID,date.Date);
            var actionResult = result as OkObjectResult;
            var contentResult = actionResult.Value as IEnumerable<dynamic>;
            Assert.That(contentResult.Count(), Is.GreaterThan(0));
        }
    }
}