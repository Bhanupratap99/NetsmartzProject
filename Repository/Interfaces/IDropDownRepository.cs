using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDropDownRepository
    {
        Task<IEnumerable<DropDown>> GetAllPlatformCodes();

        Task<IEnumerable<DropDown>> GetAllProjectCodes();

        Task<IEnumerable<DropDown>> ReportsRequiredFor();
    }
}
