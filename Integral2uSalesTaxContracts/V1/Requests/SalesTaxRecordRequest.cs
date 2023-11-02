namespace Integral2uSalesTaxContracts.V1.Requests
{
    /// <summary>
    /// Generally  to get Sales a Sales Tax Record for a country
    /// </summary>
    /// <param name="CountryCode">Code for country <see cref="ApiRoutes.SalesTax.GetCountryCodes"/></param>
    /// <param name="Zip">Required Zip for USA or where requred, optional Otherwise</param>
    /// <param name="StateProvence">Required State or Provence for Canada or where requred, other optional Otherwise</param>
    public record SalesTaxRecordRequest(string CountryCode, string Zip, string StateProvence);
}
