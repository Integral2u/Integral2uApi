namespace Integral2uSalesTaxContracts.V1.Requests
{
    /// <summary>
    /// Country Code, generally used to find sub int such as Provences
    /// </summary>
    /// <param name="CountryCode">Code fof country <see cref="ApiRoutes.SalesTax.GetCountryCodes"/></param>
    public record CountryCodeRequest(string CountryCode);
}
