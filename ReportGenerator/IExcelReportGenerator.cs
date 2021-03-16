using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ReportGenerator.Model;

namespace ReportGenerator
{
    public interface IExcelReportGenerator
    {
        void GenerateExcelReport(IEnumerable<HotelRate> hotelRates);
        Task GenerateExcelReportAsync(IEnumerable<HotelRate> hotelRates);
    }
}