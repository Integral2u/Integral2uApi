namespace Integral2uInventoryContracts.V1.Response
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="SKU">The products Stock Keeping Unit</param>
    /// <param name="Min"></param>
    /// <param name="Max"></param>
    public record ProductMinMaxResult(string SKU, double Min, double Max);
}
