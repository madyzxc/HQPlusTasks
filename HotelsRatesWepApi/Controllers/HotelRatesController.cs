using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HotelsRatesWepApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HotelsRatesWepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelRatesController : ControllerBase
    {
        private readonly ILogger<HotelRatesController> _logger;

        public HotelRatesController(ILogger<HotelRatesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var hotels = GetHotels();
            var result = hotels.Select(hotel => hotel.Hotel);
            return Ok(result);
        }
        
        [HttpGet("{hotelId}")]
        public IActionResult Get(int hotelId)
        {
            var hotels = GetHotels();
            var result = hotels.Where(hotel => hotel.Hotel.HotelId == hotelId).Select(hotel => hotel.Hotel);
            return Ok(result);
        }
        
        [HttpGet("{hotelId:int}/{arrivalDate:datetime}")]
        public IActionResult Get(int hotelId, DateTime arrivalDate)
        {
            var hotels = GetHotels();
            var hotelRates = hotels.Where(root => root.Hotel.HotelId == hotelId).Select(root => root.HotelRates)
                .FirstOrDefault();
            var result = (hotelRates ?? new List<HotelRate>()).Where(rate => rate.TargetDay.Date == arrivalDate.Date)
                .Select(rate => new
                {
                    ArrivalDate = rate.TargetDay,
                    DepartureDate = rate.TargetDay.AddDays(rate.Los),
                    Price = rate.Price.NumericInteger.ToString("#-##").Replace("-", ","),
                    rate.Price.Currency,
                    rate.RateName,
                    rate.Adults,
                    BreakfastIncluded = rate.RateTags[0].Shape ? "1" : "0"
                });
            return Ok(result);
        }
        private static IEnumerable<Root> GetHotels()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"{"App_Data/hotelsrates.json"}");
            var myJsonResponse = System.IO.File.ReadAllText(folderDetails);
            var hotels = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
            return hotels;
        }
    }
}