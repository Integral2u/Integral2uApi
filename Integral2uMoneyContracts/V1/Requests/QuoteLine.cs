namespace Integral2uMoneyContracts.V1.Requests
{
    /// <summary>
    /// The line to be re-priced, This method will not allow increase above sell as in many cases
    /// it is either bad practice or illegal to sell above shelf edge pricing. 
    /// Nor will it allow negative allow negative margin
    /// </summary>
    /// <param name="Sku">The Stock Keeping Unit or product Id</param>
    /// <param name="Cost">The Cost of an item per each or sales Unit of Measure</param>
    /// <param name="Sell">The Sell Price of an item per each or sales Unit of Measure</param>
    /// <param name="Qty">The QTY per each or sales Unit of Measure</param>
    /// <param name="MinMargin">(optional) The Minimum margin, cannot be negative and will default to 0.0</param>
    public record QuoteLine(string Sku, double Cost, double Sell, double Qty, double MinMargin = double.NaN);
}
