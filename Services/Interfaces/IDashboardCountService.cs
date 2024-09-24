using Data.Models;
using Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDashboardCountService
    {
        //Task<List<PartCountViewModel>> GetPartCountByPlatformAndPartTypeAsync(string platformCode);

        public ServiceResponse GetPartCountByPlatformAndPartTypeAsync(List<string> platformCode, List<string> projectCode, string date, string reportStatus);
     } 
}