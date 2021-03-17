using System;

namespace WebExtraction
{
    internal static class Program
    {
        private const string URL = @"https://www.booking.com/hotel/de/kempinskibristolberlin.en-gb.html";
        private const string OutputFileName = @"hotel.json";

        private static void Main(string[] args)
        {
            Console.WriteLine($"Extracting Hotel Data from {URL}");
            IHotelDataScraper scraper = new HotelDataScraper(URL);
            var hotel = scraper.ScrapeHotelData();
            Console.WriteLine($"Extracting Hotel Data completed");

            Console.WriteLine();

            Console.WriteLine($"Generating Output JSON File to {Environment.CurrentDirectory}\\{OutputFileName}");
            IHotelDataFileWriter fileWriter = new HotelDataFileWriter();
            fileWriter.WriteHotelDataToFile(hotel, OutputFileName);
            Console.WriteLine("Writing output file completed");
            
            Console.WriteLine("Please check output folder and Press enter key to Exit...");
            Console.ReadLine();
        }
    }
}
