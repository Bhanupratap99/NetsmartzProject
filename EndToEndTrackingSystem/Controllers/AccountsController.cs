using Data.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Threading.Tasks;

namespace EndToEndTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginDetails(LoginModel loginModel)
        {
            if (loginModel == null)
            {
                return BadRequest("No data found");
            }
            var captchaToken = loginModel.reCaptcha; // Assuming LoginModel has a property for CaptchaToken
            var secretKey = "6Lcn3SIqAAAAAJVp48Tjs8WuU64c-76Mk5H0d0am";
            var verifyUrl = $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={captchaToken}";

            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(30);
                var response = await httpClient.PostAsync(verifyUrl, null);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseBody);

                if (responseData.success != true)
                {
                    return Ok(new { Message = "reCAPTCHA Verification Failed.", Status = 500 });
                }

               
                var result = _accountService.LoginService(loginModel);
                    if (result.Code != "200")
                        return BadRequest(new { message = result.Message });

                    return Ok(result);

            }
        }

        [HttpPost("LogOut")]
        public IActionResult LogOut(LogoutModel logoutModel)
        {
            var result = _accountService.LogOutService(logoutModel.username);
            if (result.Code != "200")
                return BadRequest(new { message = result.Message });
            return Ok(result);
        }


    }
}
