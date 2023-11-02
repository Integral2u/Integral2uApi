namespace Integral2uSalesTaxContracts.V1
{
    public class Integral2uRestApi : Integral2uCommon.BaseIntegral2uRestApi, IIntegral2uApi
    {
        /// <summary>
        /// REST implementation of the endpoint helpers. 
        /// </summary>
        /// <param name="rapidApiKey">Your RapidAPI Key</param>
        public Integral2uRestApi(string rapidApiKey) : base(rapidApiKey, "integral2usalestax.p.rapidapi.com", "https://integral2usalestax.p.rapidapi.com/Prod/") { }
    }
}
