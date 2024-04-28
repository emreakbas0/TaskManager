using WEBPROJECT2.Models;

namespace WEBPROJECT2.Interfaces
{
    public interface IReportService
    {
        Task<string> AddReport(int ID, string categories, string reportComment);

        Task<List<Reports>> reports(int ID);

        Task<List<Reports>> reportByCat(int ID, string categories);
    }
}