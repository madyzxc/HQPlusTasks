using System.Collections.Generic;

namespace HotelsRatesWepApi.Models
{
    public class Root
    {
        public Hotel Hotel { get; set; }
        public List<HotelRate> HotelRates { get; set; }
    }
}