namespace Integral2uInventoryContracts.V1
{
    public class Integral2uHttpApi : Integral2uCommon.Integral2uHttpApi, IIntegral2uApi
    {
        public Integral2uHttpApi(string rapidApiKey) : base(rapidApiKey, "integral2uinventory.p.rapidapi.com", "https://integral2uinventory.p.rapidapi.com/Prod/") { }
    }
}