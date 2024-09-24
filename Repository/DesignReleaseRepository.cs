using Dapper;
using Data.Models;
using Data.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Repository
{
    public class DesignReleaseRepository : IDesignReleaseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public DesignReleaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("DefaultConnection");
        }

        public ServiceResponse GetAggregateCountsAsync(string platformCode, string projectCode, string date, string reportStatus)
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
                    "[NEW_GET_BO_IP_Count]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return response ?? new ServiceResponse { isError = true, Message = "No data found", Code = "404", Status = "Failure" };
            }
        }


        public ServiceResponse GetAggregateDetailsAsync(string platformCode, string projectCode, string date, string reportStatus,string aggregate)
        {

            using (var sqlConnection = new SqlConnection(_connString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PlatformCodes", platformCode);
                //parameters.Add("@ProjectCodes", projectCode);
                parameters.Add("@Status", reportStatus);
                // parameters.Add("@Date", date);
                parameters.Add("@Aggregate", aggregate);

                // Execute stored procedure and fetch result
                var response = sqlConnection.QueryFirstOrDefault<ServiceResponse>(
                    "[Sp_AggregateDetails]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return response ?? new ServiceResponse { isError = true, Message = "No data found", Code = "404", Status = "Failure" };
            }
        }
    }

}
