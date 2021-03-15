using WebExtraction.Model;

namespace WebExtraction
{
    public interface IHotelDataFileWriter
    {
        void WriteHotelDataToFile(Hotel hotel, string fileName);
    }
}