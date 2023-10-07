namespace Integral2uCommon
{
    /// <summary>
    /// Base abstract class to be extended with IBaseIntegral2uApi implementations
    /// </summary>
    public abstract class BaseIntegral2uApi : IBaseIntegral2uApi
    {
        protected readonly string RapidApiKey;
        protected readonly string RapidApiHost;
        protected readonly string RapidApiBasePath;
        /// <summary>
        /// Provides helper methods though use of extenting and implementing default interface methods by extending IBaseIntegral2uApi
        /// </summary>
        /// <param name="rapidApiKey">Your RapidAPI Key</param>
        /// <param name="rapidApiHost">Generally to be defined by extending API's</param>
        /// <param name="rapidApiBasePath">Generally to be defined by extending API's</param>
        public BaseIntegral2uApi(string rapidApiKey, string rapidApiHost, string rapidApiBasePath)
        {
            RapidApiKey = rapidApiKey;
            RapidApiHost = rapidApiHost;
            RapidApiBasePath = rapidApiBasePath;
        }

        public abstract double Post<Value>(string path, Value value);
        public abstract Result? Post<Value, Result>(string path, Value value);
    }

}
