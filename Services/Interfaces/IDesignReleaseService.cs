using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDesignReleaseService
    {
       

        public ServiceResponse GetAggregateCountsAsync(List<string> platformCode, List<string> projectCode, string date, string reportStatus);

        public ServiceResponse GetAggregateDetailsAsync(List<string> platformCode, List<string> projectCode, string date, string reportStatus, string aggregate);
       
    }
}
