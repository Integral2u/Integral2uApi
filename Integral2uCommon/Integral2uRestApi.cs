using Newtonsoft.Json;
using RestSharp;
using System.Text.Json;

namespace Integral2uCommon
{
    public class Integral2uRestApi : Integral2uApi
    {
        private readonly RestClient _client;
        public Integral2uRestApi(string rapidApiKey, string rapidApiHost, string rapidApiBasePath) : base(rapidApiKey, rapidApiHost, rapidApiBasePath)
        {
            _client = new RestClient(rapidApiBasePath);
        }

        public override double Post<Value>(string path, Value value)
        {
            var request = new RestRequest(path.ToLower(), Method.Post);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-RapidAPI-Key", RapidApiKey);
            request.AddHeader("X-RapidAPI-Host", RapidApiHost);
            var str = JsonConvert.SerializeObject(value);
            request.AddParameter("application/json", str, ParameterType.RequestBody);
            var response = _client.Execute(request);
            if (!double.TryParse(response.Content, out var d)) return double.NaN;
            return d;
        }

        public override Result? Post<Value, Result>(string path, Value value) where Result : default
        {
            var request = new RestRequest(path.ToLower(), Method.Post);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-RapidAPI-Key", RapidApiKey);
            request.AddHeader("X-RapidAPI-Host", RapidApiHost); ;
            var str = System.Text.Json.JsonSerializer.Serialize(value, new JsonSerializerOptions
            {
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals
            });
            request.AddParameter("application/json", str, ParameterType.RequestBody);
            var response = _client.Execute(request);
            if (response == null) return default;
            try
            {
                if (response.Content == null) return default;
                return JsonConvert.DeserializeObject<Result>(response.Content);
            }
            catch
            {
                return default;
            }
        }
    }
}
