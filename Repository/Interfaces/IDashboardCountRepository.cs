using Data.Models;
using Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDashboardCountRepository
    {
        // Task<List<PartCountViewModel>> GetPartCountByPlatformCodeAndPartTypeAsync(string platformCode);

        public ServiceResponse GetPartCountByPlatformAndCategoryAsync(string platformCode, string projectCode, string date, string reportStatus);
    }
}
