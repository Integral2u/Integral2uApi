namespace Integral2uSalesTaxContracts.V1.Data
{
    /// <summary>
    /// US Zipcode range, contains first and last 5 diget number for an area
    /// </summary>
    /// <param name="State">States code</param>
    /// <param name="First">First Zip</param>
    /// <param name="Last">Last Zip</param>
    public record UsZipCodeRange(string State, int First, int Last);
}
