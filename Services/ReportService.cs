using WEBPROJECT2.Interfaces;
using WEBPROJECT2.Models;

namespace WEBPROJECT2.Services
{
    public class ReportService : IReportService
    {
        readonly IRepository<Reports> _reportRepo;

        public ReportService(IRepository<Reports> reportRepo)
        {
            _reportRepo = reportRepo;
        }

        public Task<List<Reports>> reportByCat(int ID, string categories)
        {
            if(categories.Trim() == null)
            {
                throw new ArgumentNullException("Please choose the categorie of your report.");
            }

            List<Reports> records = _reportRepo.GetAll().Where(record => record.userID == ID && record.categories == categories.ToLower()).ToList();

            return Task.FromResult(records);
        }

        public Task<string> AddReport(int ID, string categories, string reportComment)
        {
            if (categories.Trim() == null && reportComment.Trim() == null)
            {
                throw new ArgumentNullException("Please fill in the blanks.");
            }

            if (categories.Trim() == null)
            {
                throw new ArgumentNullException("Please choose a categorie.");
            }

            else if (reportComment.Trim() == null)
            {
                throw new ArgumentNullException("Please make a comment about your report.");
            }

            Reports newReport = new Reports
            {
                userID = ID,
                categories = categories.ToLower(),
                insider = reportComment
            };

            _reportRepo.Addition(newReport);

            return Task.FromResult("New report is added.");
        }

        public Task<List<Reports>> reports(int ID)
        {
            List<Reports> reports = _reportRepo.GetAll().Where(record => record.userID == ID).ToList();

            return Task.FromResult(reports);
        }
    }
}
