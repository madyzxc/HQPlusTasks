using System.Collections.Generic;

namespace ReportGenerator.Model
{
    public class Root
    {
        public Hotel Hotel { get; set; }
        public List<HotelRate> HotelRates { get; set; }
    }
}