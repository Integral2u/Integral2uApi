namespace Integral2uInventoryContracts.V1.Requests
{
    /// <summary>
    /// Details of a product and it's Usage
    /// </summary>
    /// <param name="SKU">The products Stock Keeping Unit</param>
    /// <param name="Usage">The products monthy usage</param>
    public record ProductUsage(string SKU, double Usage);
}
