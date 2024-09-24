using Azure;
using Data.Models; // Assuming PartCategory is in this namespace
using Data.ViewModels;
using Repository;
using Repository.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public class DesignReleaseService : IDesignReleaseService
    {
        private readonly IDesignReleaseRepository _designReleaseRepository;

        public DesignReleaseService(IDesignReleaseRepository designReleaseRepository)
        {
            _designReleaseRepository = designReleaseRepository;
        }

        public ServiceResponse GetAggregateCountsAsync(List<string> platformCode, List<string> projectCode, string date, string reportStatus)
        {
            string platformCodesString = string.Join(",", platformCode);
            string projectCodesString = string.Join(",", projectCode);

            // Call the repository method to get the response
            var response = _designReleaseRepository.GetAggregateCountsAsync(platformCodesString, projectCodesString, date, reportStatus);

            if (response == null || response.isError == true)
            {
                // Return error response if there's an issue
                return response;
            }

            if (response.result is string jsonString)
            {
                try
                {
                    // Deserialize the JSON string into a list of objects
                    var aggregateCount = JsonSerializer.Deserialize<List<AggregateCountViewModel>>(jsonString);

                    // Assign the deserialized object to the result
                    response.result = aggregateCount;
                }
                catch (JsonException ex)
                {
                    // Handle JSON parsing errors if necessary
                    response.isError = true;
                    response.Error = $"Error processing JSON result: {ex.Message}";
                    response.result = null;
                }
            }

            return response;
        }



        public ServiceResponse GetAggregateDetailsAsync(List<string> platformCode, List<string> projectCode, string date, string reportStatus, string aggregate)
        {
            string platformCodesString = string.Join(",", platformCode);
            string projectCodesString = string.Join(",", projectCode);

            // Call the repository method to get the response
            var response = _designReleaseRepository.GetAggregateDetailsAsync(platformCodesString, projectCodesString, date, reportStatus,aggregate);

            if (response == null || response.isError == true)
            {
                // Return error response if there's an issue
                return response;
            }

            if (response.result is string jsonString)
            {
                try
                {
                    // Deserialize the JSON string into a list of objects
                    var aggregateDesignRelease = JsonSerializer.Deserialize<List<AggregateDesignReleaseViewModel>>(jsonString);

                    // Assign the deserialized object to the result
                    response.result = aggregateDesignRelease;
                }
                catch (JsonException ex)
                {
                    // Handle JSON parsing errors if necessary
                    response.isError = true;
                    response.Error = $"Error processing JSON result: {ex.Message}";
                    response.result = null;
                }
            }

            return response;
        }
    }
}
