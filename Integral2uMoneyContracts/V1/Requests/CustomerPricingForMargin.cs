using Integral2uMoneyContracts.V1.Data;
namespace Integral2uMoneyContracts.V1.Requests
{
    /// <summary>
    /// Proides multiple lines to compute pricing customer or group discount to acheived a target margin.
    /// </summary>
    /// <param name="Sales">Sales for a product with its cost and retail information</param>
    /// <param name="TargetMargin">Desired margin after discounts</param>
    /// <param name="MinMargin">Minimum margin, if a discount results in less that min this will or the minimum of retail margin will be used</param>
    public record CustomerPricingForMargin(ProductQtyCostRetail[] Sales, double TargetMargin, double MinMargin);
}
