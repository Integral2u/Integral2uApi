using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Integral2uCommon
{
    public class BaseIntegral2uHttpApi : BaseIntegral2uApi
    {
        public readonly HttpClient _client = new();
        /// <summary>
        /// Provides helper methods though use of extenting and implementing default interface methods by extending IBaseIntegral2uApi
        /// </summary>
        /// <param name="rapidApiKey">Your RapidAPI Key</param>
        /// <param name="rapidApiHost">Generally to be defined by extending API's</param>
        /// <param name="rapidApiBasePath">Generally to be defined by extending API's</param>
        public BaseIntegral2uHttpApi(string rapidApiKey, string rapidApiHost, string rapidApiBasePath) : base(rapidApiKey, rapidApiHost, rapidApiBasePath) { }

        public override Result? Post<Result>(string path) where Result : default
        {
            var uri = new Uri(new Uri(RapidApiBasePath), path.ToLower());
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Headers = {
                        { "X-RapidAPI-Key", RapidApiKey },
                        { "X-RapidAPI-Host", RapidApiHost },
                    }
            };
            var response = _client?.SendAsync(httpRequestMessage).Result;
            if (response == null) return default;
            var t = response.Content.ReadAsStringAsync();
            t.Wait();
            try
            {
                return JsonConvert.DeserializeObject<Result>(t.Result);
            }
            catch
            {
                return default;
            }
        }
        public override double Post<Value>(string path, Value value)
        {
            var uri = new Uri(new Uri(RapidApiBasePath), path.ToLower());
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Headers = {
                    { "X-RapidAPI-Key", RapidApiKey },
                    { "X-RapidAPI-Host", RapidApiHost },
                },
                Content = new StringContent(JsonConvert.SerializeObject(value))
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }

            };
            using var response = _client?.Send(httpRequestMessage);
            if (response == null) return double.NaN;
            var t = response.Content.ReadAsStringAsync();
            t.Wait();
            if (!double.TryParse(t.Result, out var d)) return double.NaN;
            return d;
        }
        public override Result? Post<Value, Result>(string path, Value value) where Result : default
        {
            var uri = new Uri(new Uri(RapidApiBasePath), path.ToLower());
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Headers = {
                        { "X-RapidAPI-Key", RapidApiKey },
                        { "X-RapidAPI-Host", RapidApiHost },
                    },
                Content = JsonContent.Create(value, null, new JsonSerializerOptions()
                {
                    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals
                })
            };
            var response = _client?.SendAsync(httpRequestMessage).Result;
            if (response == null) return default;
            var t = response.Content.ReadAsStringAsync();
            t.Wait();
            try
            {
                return JsonConvert.DeserializeObject<Result>(t.Result);
            }
            catch
            {
                return default;
            }
        }
    }
}