using Integral2uSalesTaxContracts.V1.Data;
using Integral2uSalesTaxContracts.V1.Requests;
using static Integral2uSalesTaxContracts.V1.ApiRoutes;

namespace Integral2uSalesTaxContracts.V1
{
    /// <summary>
    /// Inherited by <see cref="Integral2uHttpApi"/> and <see cref="Integral2uRestApi"/>
    /// Example: var rest = new Integral2uRestApi("[Your RapidApi Key Here]") as IIntegral2uApi;
    /// </summary>
    public interface IIntegral2uApi : Integral2uCommon.IBaseIntegral2uApi
    {
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public string[]? CountryCodes() => Post<string[]>(SalesTax.GetCountryCodes);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>CountryCodeRequest
        public string[]? StateProvenceFor(string countryCode) => StateProvenceFor(new CountryCodeRequest(countryCode));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public string[]? StateProvenceFor(CountryCodeRequest countryCode) => Post<CountryCodeRequest, string[]>(SalesTax.GetStateProvenceFor, countryCode);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>CountryCodeRequest
        public SalesTaxRecord? RecordFor(SalesTaxRecordRequest req) => Post<SalesTaxRecordRequest, SalesTaxRecord>(SalesTax.GetRecordFor, req);
    }

}
