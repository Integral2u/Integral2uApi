namespace Integral2uMoneyContracts.V1
{
    public class Integral2uHttpApi : Integral2uCommon.Integral2uHttpApi, IIntegral2uApi
    {
        public Integral2uHttpApi(string rapidApiKey) : base(rapidApiKey, "integral2umoney.p.rapidapi.com", "https://integral2umoney.p.rapidapi.com/Prod/") { }
    }
}