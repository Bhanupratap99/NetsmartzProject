using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Data.Common
{
    public class RecaptchaService
    {
        private readonly string _recaptchaSecretKey;
        private readonly HttpClient _httpClient;

        public RecaptchaService(string recaptchaSecretKey)
        {
            _recaptchaSecretKey = recaptchaSecretKey;
            _httpClient = new HttpClient();
        }

        public async Task<bool> VerifyAsync(string recaptchaResponse)
        {

            bool result = await VerifyTokenAsync(recaptchaResponse);
            try
            {
                var verificationUrl = "https://www.google.com/recaptcha/api/siteverify";
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("secret", _recaptchaSecretKey),
                    new KeyValuePair<string, string>("response", recaptchaResponse)
                });

                var response = await _httpClient.PostAsync(verificationUrl, content);
                if (!response.IsSuccessStatusCode)
                {
                    // Handle HTTP error
                    return false;
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic jsonData = JObject.Parse(responseContent);
                var success = (bool)jsonData.success;
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Exception during Recaptcha verification: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> VerifyTokenAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.google.com/recaptcha/api/siteverify?secret=");

            var content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("secret", "6Lcn3SIqAAAAAJVp48Tjs8WuU64c-76Mk5H0d0am"),
            new KeyValuePair<string, string>("response", token)
            });


            request.Content = content;
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic responseData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);


                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
