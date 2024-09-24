using Data.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System.Text.Json;

namespace Services
{
    public class DashboardCountService : IDashboardCountService
    {
        private readonly IDashboardCountRepository _dashboardCountRepository;

        public DashboardCountService(IDashboardCountRepository dashboardCountRepository)
        {
            _dashboardCountRepository = dashboardCountRepository;
        }

        public ServiceResponse GetPartCountByPlatformAndPartTypeAsync(List<string> platformCode, List<string> projectCode, string date, string reportStatus)
        {
            string platformCodesString = string.Join(",", platformCode);
            string projectCodesString = string.Join(",", projectCode);


            var response = _dashboardCountRepository.GetPartCountByPlatformAndCategoryAsync(platformCodesString, projectCodesString, date, reportStatus);

            if (response == null || response.isError == true)
            {
                return response;
            }

            // Check if the result is a JSON string
            if (response.result is string jsonString)
            {
                try
                {
                    // Deserialize the JSON string into a list of objects
                    var partCategories = JsonSerializer.Deserialize<List<PartCategory>>(jsonString);

                    PartCategory partCategory = new PartCategory();

                    partCategory.released = 0;
                    partCategory.inReleaseProcess = 0;
                    partCategory.pendingForRelease = 0;

                    // Assign the deserialized object to the result
                    response.result = partCategories;


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