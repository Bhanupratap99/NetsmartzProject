using Dapper;
using Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DropDownRepository : IDropDownRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public DropDownRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<DropDown>> GetAllPlatformCodes()
        {
            const string procedureName = "Sp_GetAllPlatformCodes";
            using var connection = new SqlConnection(_connString);
            return await connection.QueryAsync<DropDown>(procedureName, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DropDown>> GetAllProjectCodes()
        {
            const string procedureName = "Sp_GetAllProjectCodes";
            using var connection = new SqlConnection(_connString);
            return await connection.QueryAsync<DropDown>(procedureName, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DropDown>> ReportsRequiredFor()
        {
            const string procedureName = "Sp_ReportsStatus";
            using var connection = new SqlConnection(_connString);
            return await connection.QueryAsync<DropDown>(procedureName, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}


