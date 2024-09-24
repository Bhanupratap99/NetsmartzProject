using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace EndToEndTrackingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DropDownController : ControllerBase
    {
        private readonly IDropDownService _dropDownService;

        public DropDownController(IDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }

        [HttpGet("GetAllPlatformCodes")]
        public async Task<IActionResult> GetAllPlatformCodes()
        {
            var result = await _dropDownService.GetAllPlatformCodesAsync();
            return Ok(result);
        }

        [HttpGet("GetAllProjectCodes")]
        public async Task<IActionResult> GetAllProjectCodes()
        {
            var result = await _dropDownService.GetAllProjectCodesAsync();
            return Ok(result);
        }

        [HttpGet("ReportStatus")]
        public async Task<IActionResult> ReportsRequiredFor()
        {
            var result = await _dropDownService.ReportsRequiredForAsync();
            return Ok(result);
        }
    }
}