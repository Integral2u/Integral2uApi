using Integral2uMoneyContracts.V1.Data;

namespace Integral2uMoneyContracts.V1.Response
{
    /// <summary>
    /// Provides details on pricing to apply, results are based on sales volume, cost and retail.
    /// May be cases where a product could not adhear to min or target margin and are noted in exeptions.
    /// </summary>
    /// <param name="AllResults">All product pricing</param>
    /// <param name="ExceptionResults">Any product pricing exceptions where discount is different form group discounts</param>
    /// <param name="GroupDiscount">The group discount applied to the group of sku's except for exceptions</param>
    /// <param name="AcheivedMargin">Resulting Margin</param>
    public record CustomerPricingForMarginResults(ProductPricing[] AllResults, ProductPricing[] ExceptionResults, double GroupDiscount, double AcheivedMargin);

}
