using System.IO;
using Newtonsoft.Json;
using ReportGenerator.Model;

namespace ReportGenerator
{
    public class FileReader : IFileReader
    {
        private readonly string _inputFileName;

        public FileReader(string inputFileName)
        {
            _inputFileName = inputFileName;
        }

        public Root ReadFile()
        {
            var myJsonResponse = File.ReadAllText(_inputFileName);
            return JsonConvert.DeserializeObject<Root>(myJsonResponse);
        }
    }
}