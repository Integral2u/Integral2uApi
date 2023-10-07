namespace Integral2uInventoryContracts.V1.Response
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="SKU">The products Stock Keeping Unit</param>
    /// <param name="Qty"></param>
    public record ProductQtyResult(string SKU, double Qty);
}
