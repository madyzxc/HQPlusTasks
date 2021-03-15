using System;
using NUnit.Framework;
using WebExtraction;
using WebExtraction.Model;

namespace WebExtractionTest
{
    [TestFixture]
    public class HotelDataFileWriterTests
    {
        [Test]
        public void WriteHotelDataToFile_PassedEmptyFileName_ThrowsException()
        {
            IHotelDataFileWriter writer = new HotelDataFileWriter();
            Hotel hotel = new Hotel()
            {
                Name = "Test Hotel",
                Address = "Test Address"
            };
            Assert.That(()=> writer.WriteHotelDataToFile(hotel,""),Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}