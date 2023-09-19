using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebApi.Models;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private static HttpClient _httpClient;
        private static string _baseUrl = "https://localhost:7168/api/";
        private static string _token;

        [TestInitialize]
        public void Initialize()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);

         
            var registerVM = new RegisterViewModel
            {
                Email = "teste@teste.com",
                Senha = "G@lo1234"
            };
            var registerContent = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var registerResponse = _httpClient.PostAsync("Auth/Registrar", registerContent).Result;
            var registerResult = registerResponse.Content.ReadAsStringAsync().Result;
            _token = registerResult;
        }

        [TestMethod]
        public void TestMethod1()
        {
            
            Assert.IsFalse(string.IsNullOrWhiteSpace(_token));
        }

        [TestMethod]
        public void TestMethod2()
        {
            
            var loginVM = new LoginViewModel
            {
                Email = "teste@teste.com",
                Senha = "G@lo1234"
            };
            var loginContent = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var loginResponse = _httpClient.PostAsync("Auth/Login", loginContent).Result;
            var loginResult = loginResponse.Content.ReadAsStringAsync().Result;
            var loginToken = JsonConvert.DeserializeObject<string>(loginResult);

           
            Assert.IsFalse(string.IsNullOrWhiteSpace(loginToken));
        }

        [TestMethod]
        public void TestMethod3()
        {
            
            var loginVM = new LoginViewModel
            {
                Email = "email_invalido@teste.com",
                Senha = "SenhaInvalida123"
            };
            var loginContent = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var loginResponse = _httpClient.PostAsync("Auth/Login", loginContent).Result;

            Assert.IsFalse(loginResponse.IsSuccessStatusCode); 
            Assert.IsTrue(loginResponse.StatusCode == System.Net.HttpStatusCode.BadRequest); 
        }
    }
}
