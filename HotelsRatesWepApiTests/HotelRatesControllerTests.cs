using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HotelsRatesWepApi;
using HotelsRatesWepApi.Controllers;
using HotelsRatesWepApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
        public void Get_NotPassedParameters_ReturnsListOfHotels()
        {
            var controller = new HotelRatesController();
            IActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkObjectResult;
            Assert.IsNotNull(actionResult);
        }
    }
}