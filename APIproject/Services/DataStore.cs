using APIproject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace APIproject.Services
{
    public class DataStore
    {
        HttpClient _client;

        public DataStore()
        {
            _client = new HttpClient(GetInsecureHandler());
            _client.BaseAddress = new Uri($"https://192.168.1.105:45455");
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;


        public async Task<bool> Register(User user)
        {
            if (user != null || !IsConnected)
            {
                var serializeUser = JsonConvert.SerializeObject(user);

                var odp = await _client.PostAsync($"api/Users/Register", new StringContent(serializeUser, Encoding.UTF8, "application/json"));

                if (odp.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Login(User user)
        {
            if (user != null || !IsConnected)
            {
                var serializeUser = JsonConvert.SerializeObject(user);

                var odp = await _client.PostAsync($"api/Users", new StringContent(serializeUser, Encoding.UTF8, "application/json"));

                if (odp.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<string>> RegisteredUsers()
        {
            var odp = await _client.GetAsync($"api/Users");
            if (odp.IsSuccessStatusCode)
            {
                var content = await odp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<string>>(content);
            }
            return new List<string>();
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain,
            errors) =>
            {
                return true;
            };
            return handler;
        }
    }
}
