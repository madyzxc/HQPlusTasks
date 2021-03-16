using System;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml.Drawing.Vml;

namespace ReportGenerator
{
    internal static class Program
    {
        private const string InputFileName = @"hotelrates.json";
        private const string OutputFileName = @"report.xlsx";

        private static async Task Main(string[] args)
        {
            IFileReader reader = new FileReader(InputFileName);
            var root = reader.ReadFile();
            
            IExcelReportGenerator generator = new ExcelReportGenerator(OutputFileName);
            await generator.GenerateExcelReportAsync(root.HotelRates);
        }

        
        
        
    }
}