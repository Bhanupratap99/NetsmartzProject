using Dapper;
using Data.Common;
using Data.Models;
using Data.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        private IConfiguration _configuration;
        private static string _connString;
        public AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = configuration.GetConnectionString("DefaultConnection");
        }

        public dynamic LoginRepository(LoginModel loginModel, bool aldapValidated, string Token)
        {
            using (var sqlConnection = new SqlConnection(_connString))
            {
                try
                {
                    ServiceResponse response = new ServiceResponse();

                    var parameter = new DynamicParameters();

                    // Decrypting the values
                    string decryptedUsername = EncryptionService.Decrypt(loginModel.username);
                    string decryptedPassword = EncryptionService.Decrypt(loginModel.password);
                    string decryptedIpAddress = loginModel.IpAddress != null ? EncryptionService.Decrypt(loginModel.IpAddress) : null;
                    string decryptedBrowserName = loginModel.BrowserName != null ? EncryptionService.Decrypt(loginModel.BrowserName) : null;
                    string decryptedBrowserVersion = loginModel.BrowserVersion != null ? EncryptionService.Decrypt(loginModel.BrowserVersion) : null;

            

                    // Adding decrypted parameters to DynamicParameters
                    parameter.Add("@Username", decryptedUsername);
                    parameter.Add("@Password", decryptedPassword);
                    parameter.Add("@Token", Token);
                    parameter.Add("@AldapValidated", aldapValidated);
                    parameter.Add("@IpAddress", (object)decryptedIpAddress ?? DBNull.Value);
                    parameter.Add("@BrowserName", (object)decryptedBrowserName ?? DBNull.Value);
                    parameter.Add("@BrowserVersion", (object)decryptedBrowserVersion ?? DBNull.Value);

                    return sqlConnection.Query<dynamic>("Sp_LoginUser", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return new ServiceResponse
                    {
                        Message = "An error occurred",
                        Status = "Failure",
                        Code = "500",
                        isError = true,
                    };
                }
            }
        }


        public dynamic LogoutRepository(string username)
        {
            var response = new ServiceResponse();
            try
            {
                using (var sqlConnection = new SqlConnection(_connString))
                {
                    var parameter = new DynamicParameters();
                    string decryptedUsername = EncryptionService.Decrypt(username);
                    parameter.Add("@username", decryptedUsername);

                    var result = sqlConnection.QueryFirstOrDefault<dynamic>(
                        "Sp_LogoutUser",
                        parameter,
                        commandType: CommandType.StoredProcedure
                    );

                    response.Status = result?.Code == "200" ? "Success" : "Failure";
                    response.Code = result?.Code ?? "400";
                    response.Message = result?.Message ?? "Logout failed";
                }
            }
            catch (Exception ex)
            {
                response.Status = "Failure";
                response.Code = "400";
                response.Message = "Logout failed: " + ex.Message;
            }
            return response;
        }



    }
}

