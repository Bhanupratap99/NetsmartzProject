using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDesignReleaseRepository
    {
        public ServiceResponse GetAggregateCountsAsync(string platformCode, string projectCode, string date, string reportStatus);

        public ServiceResponse GetAggregateDetailsAsync(string platformCode, string projectCode, string date, string reportStatus, string aggregate);
    }
}