using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Data.NetworkHandler
{
    class NetworkHelper
    {
        public static HttpClient Client { get; set; }
        public static async Task InitializeClientAsync()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string token = await AuthManager.GetAuthTokenAsync("679547111");
            Client.DefaultRequestHeaders.Add("Authorization", "Zoho-oauthtoken " + token);
            Client.BaseAddress = new Uri("https://mail.zoho.com");

        }
    }
}
