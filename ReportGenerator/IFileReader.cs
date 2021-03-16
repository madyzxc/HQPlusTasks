using ReportGenerator.Model;

namespace ReportGenerator
{
    public interface IFileReader
    {
        Root ReadFile();
    }
}