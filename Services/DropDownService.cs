using Data.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DropDownService : IDropDownService
    {
        private readonly IDropDownRepository _dropDownRepository;

        public DropDownService(IDropDownRepository dropDownRepository)
        {
            _dropDownRepository = dropDownRepository;
        }

        public async Task<object> GetAllPlatformCodesAsync()
        {
            var platformCodes = await _dropDownRepository.GetAllPlatformCodes();
            var result = new List<object>
            {
                new
                {
                    Platform_Code = platformCodes.Select(pc => pc.Platform_Code).ToList()
                }
            };
            return result;
        }

        public async Task<object> GetAllProjectCodesAsync()
        {
            var projectCodes = await _dropDownRepository.GetAllProjectCodes();
            var result = new List<object>
            {
                new
                {
                    Project_Code = projectCodes.Select(pc => pc.Project_Code).ToList()
                }
            };
            return result;
        }

        public async Task<object> ReportsRequiredForAsync()
        {
            var reportsrequiredfor = await _dropDownRepository.ReportsRequiredFor();
            var result = new List<object>
            {
                new
                {
                    reports_required_for = reportsrequiredfor.Select(pc => pc.Status).ToList()
                }
            };
            return result;
        }
    }
}

