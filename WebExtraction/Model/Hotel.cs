using System.Collections.Generic;

namespace WebExtraction.Model
{
    class Hotel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Classification Classification { get; set; }
        public int Reviewpoints { get; set; }
        public int NumberOfReviews { get; set; }
        public List<Category> RoomCategories { get; set; }
        public List<Hotel> AlternativeHotels { get; set; }
    }
}
