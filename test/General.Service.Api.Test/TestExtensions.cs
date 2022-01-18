using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace General.Service.Api.Test
{
    internal static class TestExtensions
    {
        internal static async Task<T> ReadJsonAsync<T>(this HttpResponseMessage response)
            where T : class
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
            var responseString = await response.Content.ReadAsStringAsync();
            T obj = JsonConvert.DeserializeObject<T>(responseString, settings);
            return obj;
        }
    }
}
