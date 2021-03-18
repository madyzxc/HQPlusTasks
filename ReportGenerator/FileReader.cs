using System;
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
            if (string.IsNullOrWhiteSpace(inputFileName)) throw new ArgumentNullException(nameof(inputFileName));
            _inputFileName = inputFileName;
        }

        public Root ReadFile()
        {
            var myJsonResponse = File.ReadAllText(_inputFileName);
            if(string.IsNullOrWhiteSpace(myJsonResponse)) throw new ArgumentNullException("error rading file");
            return JsonConvert.DeserializeObject<Root>(myJsonResponse);
        }
    }
}