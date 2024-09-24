using Data.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace EndToEndTrackingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardCountService _dashboardCountService;

        public DashboardController(IDashboardCountService dashboardCountService)
        {
            _dashboardCountService = dashboardCountService;
        }

        [HttpPost("GetPartTypeCount")]
        public async Task<ActionResult<ServiceResponse>> GetPartCountByPlatformAndCategory([FromBody] PartCountRequest request)
        {
            // Validate input
            if (request.Platform_Code == null || !request.Platform_Code.Any() || string.IsNullOrEmpty(request.Report_Status))
            {
                return BadRequest(new ServiceResponse
                {
                    isError = true,
                    Code = "400",
                    Message = "Platform code and Report status are required.",
                    Status = "Failure"
                });
            }

            var normalizedReportStatus = request.Report_Status.ToUpper();

            // Validate ReportStatus
            if (normalizedReportStatus != "ACTIVE" && normalizedReportStatus != "ALL")
            {
                return BadRequest(new ServiceResponse
                {
                    isError = true,
                    Code = "400",
                    Message = "Invalid Report status. It must be 'ACTIVE' or 'ALL'.",
                    Status = "Failure"
                });
            }

            // Call the service
            var result = _dashboardCountService.GetPartCountByPlatformAndPartTypeAsync(request.Platform_Code, request.Project_Code, request.Date, request.Report_Status);

            // Check for errors in the result
            if (result == null || result.isError == true)
            {
                return NotFound(new ServiceResponse
                {
                    isError = true,
                    Code = "404",
                    Message = "No data found for the provided platform code and report status.",
                    Status = "Failure"
                });
            }

            // Return the successful response
            return Ok(result);
        }
    }
}