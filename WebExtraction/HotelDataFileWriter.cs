using System;
using System.IO;
using System.Text.Json;
using WebExtraction.Model;

namespace WebExtraction
{
    public class HotelDataFileWriter : IHotelDataFileWriter
    {
        public void WriteHotelDataToFile(Hotel hotel, string fileName)
        {
            if (hotel == null) throw new ArgumentNullException(nameof(hotel));
            if ( string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));
            
            var hotelDataAsJsonString = JsonSerializer.Serialize(hotel);
            File.WriteAllText(fileName, hotelDataAsJsonString);
        }
    }
}