namespace Integral2uCommon
{
    public abstract class Integral2uApi : IIntegral2uApi
    {
        protected readonly string RapidApiKey;
        protected readonly string RapidApiHost;
        protected readonly string RapidApiBasePath;

        public Integral2uApi(string rapidApiKey, string rapidApiHost, string rapidApiBasePath)
        {
            RapidApiKey = rapidApiKey;
            RapidApiHost = rapidApiHost;
            RapidApiBasePath = rapidApiBasePath;
        }

        public abstract double Post<Value>(string path, Value value);
        public abstract Result? Post<Value, Result>(string path, Value value);
    }

}
