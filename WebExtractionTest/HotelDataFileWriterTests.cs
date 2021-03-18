using System;
using NUnit.Framework;
using WebExtraction;
using WebExtraction.Model;

namespace WebExtractionTest
{
    [TestFixture]
    public class HotelDataFileWriterTests
    {
        private IHotelDataFileWriter _writer;
        private Hotel _hotel;
        
        [SetUp]
        public void SetUp()
        {
            _writer = new HotelDataFileWriter();
            _hotel = new Hotel()
            {
                Name = "Test Hotel",
                Address = "Test Address"
            };
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void WriteHotelDataToFile_PassedWrongFileName_ThrowsException(string wrongFileName)
        {
            Assert.That(()=> _writer.WriteHotelDataToFile(_hotel,wrongFileName),Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}