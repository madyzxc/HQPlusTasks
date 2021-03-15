using System.Collections.Generic;

namespace WebExtraction.Model
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Classification Classification { get; set; }
        public float ReviewPoints { get; set; }
        public int NumberOfReviews { get; set; }
        public IEnumerable<string> RoomCategories { get; set; }
    }
}
