namespace Integral2uMoneyContracts.V1.Data
{
    /// <summary>
    /// Product pricing
    /// </summary>
    /// <param name="SKU">Product's Stock Keeping Unit</param>
    /// <param name="Cost">Cost per EA</param>
    /// <param name="Retail">Retail Price per EA</param>
    /// <param name="Net">Net Price after Discount</param>
    /// <param name="Discount">Discount to apply</param>
    /// <param name="Margin">Margin percent after Discount</param>
    public record ProductPricing(string SKU, double Cost, double Retail, double Net, double Discount, double Margin);
}
