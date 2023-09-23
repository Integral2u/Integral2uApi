using Integral2uMoneyContracts.V1.Requests;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Integral2uMoneyContracts.V1.ApiRoutes;

namespace Integral2uMoneyContracts.V1
{
    public class Integral2uRestApi: Integral2uApi
    {
        private readonly RestClient _client;
        private readonly string _rapidApiKey;
        private readonly string _rapidApiHost = "integral2umoney.p.rapidapi.com";

        public Integral2uRestApi(string apiKey)
        {
            _client = new RestClient("https://integral2umoney.p.rapidapi.com/Prod");
            _rapidApiKey = apiKey;
        }

        public override double Post<Value>(string path, Value value)
        {
            var request = new RestRequest(path.ToLower(), Method.Post);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-RapidAPI-Key", _rapidApiKey);
            request.AddHeader("X-RapidAPI-Host", _rapidApiHost);
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
            request.AddHeader("X-RapidAPI-Key", _rapidApiKey);
            request.AddHeader("X-RapidAPI-Host", _rapidApiHost);;
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
