using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ReportGenerator.Model;

namespace ReportGenerator
{
    public class ExcelReportGenerator : IExcelReportGenerator
    {
        private readonly FileInfo _file;

        public ExcelReportGenerator(string outputFileName)
        {
            _file = new FileInfo(outputFileName);
        }
        public void GenerateExcelReport(IEnumerable<HotelRate> hotelRates)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DeleteIfExistsFile(_file);
            using var package = new ExcelPackage(_file);
            var worksheet = package.Workbook.Worksheets.Add("HotelRatesReport");
            var range = worksheet.Cells["A1"].LoadFromCollection(MapHotelObject(hotelRates), true);
            range.AutoFitColumns();
            package.Save();
        }
        public async Task GenerateExcelReportAsync(IEnumerable<HotelRate> hotelRates)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DeleteIfExistsFile(_file);
            using var package = new ExcelPackage(_file);
            var worksheet = package.Workbook.Worksheets.Add("HotelRatesReport");
            var range = worksheet.Cells["A1"].LoadFromCollection(MapHotelObject(hotelRates), true);
            worksheet.Column(1).Style.Numberformat.Format = "dd-mm-yy";
            worksheet.Column(2).Style.Numberformat.Format = "dd-mm-yy";
            range.AutoFitColumns();
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            await package.SaveAsync();
        }
        private IEnumerable<HotelRateWriteDto> MapHotelObject(IEnumerable<HotelRate> hotelRates)
        {
            return hotelRates.Select(hotelRate => new HotelRateWriteDto
                {
                    ArrivalDate = hotelRate.TargetDay,
                    DepartureDate = hotelRate.TargetDay.AddDays(hotelRate.Los),
                    Price = hotelRate.Price.NumericInteger.ToString("#-##").Replace("-",","),
                    Currency = hotelRate.Price.Currency,
                    RateName = hotelRate.RateName,
                    Adults = hotelRate.Adults,
                    BreakfastIncluded = hotelRate.RateTags[0].Shape ? "1" : "0"
                })
                .ToList();
        }
        private static void DeleteIfExistsFile(FileInfo file)
        {
            if(file.Exists) file.Delete();
        }
    }
}