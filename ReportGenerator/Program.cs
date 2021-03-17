using System;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml.Drawing.Vml;

namespace ReportGenerator
{
    internal static class Program
    {
        private const string InputFileName = @"Content\hotelrates.json";
        private const string OutputFileName = @"Content\report.xlsx";

        private static async Task Main(string[] args)
        {
            Console.WriteLine($"Reading Input file from {InputFileName}");
            IFileReader reader = new FileReader(InputFileName);
            var root = reader.ReadFile();
            Console.WriteLine("Reading file completed");

            Console.WriteLine();

            Console.WriteLine($"Generating output report file to {Environment.CurrentDirectory}\\{OutputFileName}");
            IExcelReportGenerator generator = new ExcelReportGenerator(OutputFileName);
            await generator.GenerateExcelReportAsync(root.HotelRates);
            Console.WriteLine("Writing output file completed");
            
            Console.WriteLine("Please check output folder and Press enter key to Exit...");
            Console.ReadLine();

        }




    }
}