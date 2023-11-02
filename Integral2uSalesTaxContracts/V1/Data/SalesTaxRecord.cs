namespace Integral2uSalesTaxContracts.V1.Data
{
    /// <summary>
    /// A Sales Tax Record for a Given Country or Area.
    /// Optional Rates are returned as -1 if not available.
    /// </summary>
    /// <param name="CountryCode">The Country Code</param>
    /// <param name="Country">Name of the Country</param>
    /// <param name="Zip">The Area's Zip code in relation to the Sales Tax Record</param>
    /// <param name="StateProvence">The State or Provence in relation to the Sales Tax Record</param>
    /// <param name="StandardRate">Standard Rate</param>
    /// <param name="ReducedRate">(Optional)Rate applied to Various Goods or Services</param>
    /// <param name="ReducedRateAlt">(Optional)Rate applied to Various Goods or Services</param>
    /// <param name="SuperReducedRate">(Optional)Rate applied to Various Goods or Services</param>
    /// <param name="ParkingRate">(Optional)Rate applied to Various Goods or Services</param>
    /// <param name="LastUpdate">(Optional)Date this record was last updated</param>
    /// <param name="Name">Name of Tax for example GST/VAT</param>
    public record SalesTaxRecord(string CountryCode, string Country, string Zip, string StateProvence, double StandardRate, double ReducedRate, double ReducedRateAlt, double SuperReducedRate, double ParkingRate, DateTime LastUpdate, string Name);

}
