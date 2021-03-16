using System;
using System.Collections.Generic;

namespace ReportGenerator.Model
{
    public class HotelRateWriteDto
    {
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string RateName { get; set; }
        public int Adults { get; set; }
        public string BreakfastIncluded { get; set; }
    }
}