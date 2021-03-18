using System;
using NUnit.Framework;
using ReportGenerator;

namespace ReportGeneratorTests
{
    public class FileReaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void FileReader_WhenConstructorPassedWrongValues_ThrowsException(string wrongFileName)
        {
            Assert.That(()=> new FileReader(wrongFileName),Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}