namespace Integral2uSalesTaxContracts.V1
{
    public class Integral2uHttpApi : Integral2uCommon.BaseIntegral2uHttpApi, IIntegral2uApi
    {
        /// <summary>
        /// HTTP implementation of the endpoint helpers. 
        /// </summary>
        /// <param name="rapidApiKey">Your RapidAPI Key</param>
        public Integral2uHttpApi(string rapidApiKey) : base(rapidApiKey, "integral2salestax.p.rapidapi.com", "https://integral2usalestax.p.rapidapi.com/Prod/") { }
    }
}