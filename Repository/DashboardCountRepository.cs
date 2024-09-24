using Dapper;
using Data.Models;
using Data.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Repository
{
    public class DashboardCountRepository : IDashboardCountRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public DashboardCountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = configuration.GetConnectionString("DefaultConnection");
        }

        public ServiceResponse GetPartCountByPlatformAndCategoryAsync(string platformCode, string projectCode, string date, string reportStatus)
        {
            using (var sqlConnection = new SqlConnection(_connString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PlatformCodes", platformCode);
                parameters.Add("@ProjectCodes", projectCode);
                parameters.Add("@ReportStatus", reportStatus);
                parameters.Add("@Date", date);

                // Execute stored procedure and fetch result
                var response = sqlConnection.QueryFirstOrDefault<ServiceResponse>(
                    "[sp_GetPartCountByPlatformAndCategory]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return response ?? new ServiceResponse { isError = true, Message = "No data found", Code = "404", Status = "Failure" };
            }
        }


    }
}
