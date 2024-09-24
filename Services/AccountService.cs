using Services.Interfaces;
using Repository.Interfaces;
using Data.Common;
using Data.Models;
using Microsoft.Extensions.Configuration;
using Data.ViewModels;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public ServiceResponse LoginService(LoginModel loginModel)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel();

                {
                  
                    string token = GenerateToken.GetToken(loginModel, _configuration);
                    var result = _accountRepository.LoginRepository(loginModel, true, token);
                    response.Status = result.Status;
                    response.Code = result.Code;
                    response.Message = result.Message;
                    

                    if (result.Code == "200")
                    {
                        userDetailsViewModel.UserName = result.UserName;
                        userDetailsViewModel.Token = token;
                        response.result = userDetailsViewModel;
                    }

                }
            }
            catch (Exception ex)
            {
                response.Status = "Failure";
                response.Code = "400";
                response.isError = true;
                response.Message = "System can not find the combination of this Username and password, please try again";
            }
            return response;
        }



        public ServiceResponse LogOutService(string username)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {   
                var logoutResult = _accountRepository.LogoutRepository(username);

                if (logoutResult.Code == "200")
                {
                    response.Status = "Success";
                    response.Code = "200";
                    response.Message = "Logout successful";
                }
                else
                {
                    response.Status = "Failure";
                    response.Code = "400";
                    response.Message = "Logout failed: " + logoutResult.Message;
                }
            }
            catch (Exception ex)
            {
                response.Status = "Failure";
                response.Code = "500";
                response.isError = true;
                response.Message = "Failed to logout: " + ex.Message;
            }
            return response;
        }


    }
}


