namespace Integral2uInventoryContracts.V1
{
    public class Integral2uHttpApi : Integral2uCommon.BaseIntegral2uHttpApi, IIntegral2uApi
    {
        /// <summary>
        /// HTTP implementation of the endpoint helpers. 
        /// </summary>
        /// <param name="rapidApiKey">Your RapidAPI Key</param>
        public Integral2uHttpApi(string rapidApiKey) : base(rapidApiKey, "integral2uinventory.p.rapidapi.com", "https://integral2uinventory.p.rapidapi.com/Prod/") { }
    }
}