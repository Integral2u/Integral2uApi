using Integral2uMoneyContracts.V1.Requests;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Integral2uMoneyContracts.V1
{
    public class Integral2uHttpApi : Integral2uApi
    {
        private readonly string _rapidApiKey;
        private readonly string _rapidApiHost = "integral2umoney.p.rapidapi.com";
        private readonly string _rapidApiBasePath = "https://integral2umoney.p.rapidapi.com/Prod/";
        public readonly HttpClient _client = new();
        public Integral2uHttpApi(string apiKey) => _rapidApiKey = apiKey;
        public override double Post<Value>(string path, Value value)
        {
            var uri = new Uri(new Uri(_rapidApiBasePath), path.ToLower());
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Headers = {
                    { "X-RapidAPI-Key", _rapidApiKey },
                    { "X-RapidAPI-Host", _rapidApiHost },
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
            var uri = new Uri(new Uri(_rapidApiBasePath), path.ToLower());
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Headers = {
                        { "X-RapidAPI-Key", _rapidApiKey },
                        { "X-RapidAPI-Host", _rapidApiHost },
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