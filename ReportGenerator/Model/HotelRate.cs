using System;
using System.Collections.Generic;

namespace ReportGenerator.Model
{
    public class HotelRate
    {
        public int Adults { get; set; }
        public int Los { get; set; }
        public Price Price { get; set; }
        public string RateDescription { get; set; }
        public string RateId { get; set; }
        public string RateName { get; set; }
        public List<RateTag> RateTags { get; set; }
        public DateTime TargetDay { get; set; }
    }
}