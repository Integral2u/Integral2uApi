namespace Integral2uMoneyContracts.V1.Data
{
    /// <summary>
    /// Data containing sales for a customer or group of customers for products.
    /// Note: Products should have similar Margin Bands
    /// </summary>
    /// <param name="SKU">Product's Stock Keeping Unit</param>
    /// <param name="Qty">Sales Qty</param>
    /// <param name="Cost">Cost per EA</param>
    /// <param name="Retail">Retail Price per EA</param>
    public record ProductQtyCostRetail(string SKU, double Qty, double Cost, double Retail);
}
