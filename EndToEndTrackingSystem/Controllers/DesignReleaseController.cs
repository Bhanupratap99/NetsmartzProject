using Data.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndToEndTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignReleaseController : ControllerBase
    {
        private readonly IDesignReleaseService _service;

        public DesignReleaseController(IDesignReleaseService service)
        {
            _service = service;
        }

        [HttpPost("AggregateCount")]
        public async Task<ActionResult<IEnumerable<AggregateCountViewModel>>> GetAggregateCounts([FromBody] PartCountRequest request)
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



            var result = _service.GetAggregateCountsAsync(request.Platform_Code, request.Project_Code, request.Date, request.Report_Status);

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

        [HttpPost("AggregateDetails")]
        public async Task<ActionResult<IEnumerable<AggregateCountViewModel>>> GetAggregateDetails([FromBody] DesignReleaseRequest request)
        {


            // Validate input
            if (request.Platform_Code == null || !request.Platform_Code.Any() ||
                string.IsNullOrEmpty(request.Report_Status) ||
                string.IsNullOrEmpty(request.Aggregate))
            {
                return BadRequest(new ServiceResponse
                {
                    isError = true,
                    Code = "400",
                    Message = "Platform code, Report status, and Aggregate are required.",
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



            var result = _service.GetAggregateDetailsAsync(request.Platform_Code, request.Project_Code, request.Date, request.Report_Status,request.Aggregate);

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


       