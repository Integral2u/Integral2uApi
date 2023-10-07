namespace Integral2uInventoryContracts.V1.Data
{
    /// <summary>
    /// Like StockLevelData but contains SKU for reference
    /// </summary>
    /// <param name="SKU">The products Stock Keeping Unit</param>
    /// <param name="PotentialAFS">Potential should be what will be available SOH+PO-SO</param>
    /// <param name="Min">Minimum stock</param>
    /// <param name="Max">Maximum stock</param>
    /// <param name="PackSize">QTY pack must be ordered in multiples of</param>
    public record ProductStockLevelData(string SKU, double PotentialAFS, double Min, double Max, double PackSize);
}
