namespace Integral2uMoneyContracts.V1
{
    public class Integral2uRestApi: Integral2uCommon.Integral2uRestApi, IIntegral2uApi
    {
        public Integral2uRestApi(string rapidApiKey) : base(rapidApiKey, "integral2umoney.p.rapidapi.com", "https://integral2umoney.p.rapidapi.com/Prod/") { }
    }
}
