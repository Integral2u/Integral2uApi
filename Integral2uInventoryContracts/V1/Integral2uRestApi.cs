namespace Integral2uInventoryContracts.V1
{
    public class Integral2uRestApi : Integral2uCommon.Integral2uRestApi, IIntegral2uApi
    {
        public Integral2uRestApi(string rapidApiKey) : base(rapidApiKey, "integral2uinventory.p.rapidapi.com", "https://integral2uinventory.p.rapidapi.com/Prod/") { }
    }
}
