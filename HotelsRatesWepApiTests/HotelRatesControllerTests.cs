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
using NUnit.Framework;

namespace HotelsRatesWepApiTests
{
    public class HotelRatesControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Get_NotPassedParameters_ReturnsListOfHotels()
        {
            var controller = new HotelRatesController();
            var result = controller.Get() ;
            var actionResult = result as OkObjectResult;
            var contentResult = actionResult.Value as IEnumerable<Hotel>;
            Assert.That(contentResult.Count(), Is.EqualTo(2));
            var hotelid = (new List<HotelsRatesWepApi.Models.Hotel>(contentResult)[0]).HotelId;
            Assert.That(hotelid, Is.EqualTo(2));

        }
    }
}