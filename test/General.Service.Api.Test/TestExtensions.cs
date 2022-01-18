using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace General.Service.Api.Test
{
    internal static class TestExtensions
    {
        /// <summary>
        /// Вычитывание структуры из ответа
        /// </summary>
        /// <typeparam name="T">тип структуры</typeparam>
        /// <param name="response">ответ http запроса</param>
        /// <returns>экземпляр структуры</returns>
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

        /// <summary>
        /// Преобразование объекта в контент для запроса
        /// </summary>
        /// <param name="data">объект для запроса</param>
        /// <returns>контент для запроса</returns>
        internal static HttpContent ToHttpContent(this object data)
        {
            var content = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }
    }
}
