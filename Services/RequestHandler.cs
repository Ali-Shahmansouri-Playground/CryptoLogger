using CryptoLogger.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLogger.Services
{
    public static class RequestHandler<T> where T : class
    {

        private const string baseUrl = "https://api.wallex.ir/v1/currencies/stats";


        public static async Task<T> GetDataAsync()
        {
            var route = new Uri(baseUrl);

            using (var client = new HttpClient())
            {
                var res = await client.GetAsync(route);
                var data = await res.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(data);

            }

        }
    }
}
