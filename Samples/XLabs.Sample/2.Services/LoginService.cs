using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XLabs.Sample.ViewModel;

namespace XLabs.Sample.Services
{
    public class LoginService
    {
        public async Task<LoginViewModel> LoginAsync(string username, string password)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://cloud.tescar.cn/home/") };
            var response = await client.GetAsync("LoginSubmit2?UserName=" + username + "&Pwd=" + password + "&isspe=1");
            var loginJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<LoginViewModel>(loginJson);

        }
    }
}
