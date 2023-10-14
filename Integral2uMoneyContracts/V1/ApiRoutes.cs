using Newtonsoft.Json.Linq;
using static Integral2uMoneyContracts.V1.ApiRoutes;

namespace Integral2uMoneyContracts.V1
{
    /// <summary>
    /// API Endpoint structure
    /// </summary>
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = $"{Root}/{Version}";
        public static class Helpers
        {
            /// <summary>
            /// Gets the APIs user subscription
            /// </summary>
            public const string GetUserSubscription = $"{Base}/{nameof(Helpers)}/UserSubscription";
        }
        public static class Investment
        {
            /// <summary>
            /// Return on Investment (ROI) expressed as a percentage and is calculated by 
            /// dividing an investment's net profit (or loss) by its initial cost.
            /// </summary>
            public const string GetROIFromRevenueCost = $"{Base}/{nameof(Investment)}/ROIFromRevenueCost";
            /// <summary>
            /// Return on Investment (ROI) expressed as a percentage and is calculated by 
            /// dividing an investment's net profit (or loss) by its initial cost.
            /// </summary>
            public const string GetROIFromMarginCost = $"{Base}/{nameof(Investment)}/ROIFromMarginCost";
            /// <summary>
            /// Net present value (NPV) is the difference between the present value of cash inflows and the 
            /// present value of cash outflows over a period of time
            /// </summary>
            public const string GetNPVFromCashFlows = $"{Base}/{nameof(Investment)}/NPVFromCashFlows";
            /// <summary>
            /// Net present value (NPV) is the difference between the present value of cash inflows and the 
            /// present value of cash outflows over a period of time
            /// </summary>
            public const string GetNPVFromCashFlow = $"{Base}/{nameof(Investment)}/NPVFromCashFlow";
            /// <summary>
            /// The internal rate of return (IRR) is a metric used in financial analysis to
            /// estimate the profitability of potential investments. 
            /// IRR is a discount rate that makes the net present value (NPV) of all cash flows equal 
            /// to zero in a discounted cash flow analysis.
            /// </summary>
            public const string GetIRRFromCashFlow = $"{Base}/{nameof(Investment)}/IRRFromCashFlow";
        }
        public static class Discount
        {
            /// <summary>
            /// Returns the discount applied given the retail and net prices
            /// </summary>
            public const string GetFromRetailNet = $"{Base}/{nameof(Discount)}/FromRetailNet";
        }
        public static class Pricing
        {
            /// <summary>
            /// Attempts to reduce a quote by a given value. Decreases all sell until a defined min margin percent or 0% by default
            /// the reduction value is always removed regardless  of sign. Precision is defined most granular decimal place in all sells.
            /// </summary>
            public const string ReduceQuoteByValue = $"{Base}/{nameof(Pricing)}/ReduceQuoteByValue";
            /// <summary>
            /// Determines best discount to applied for a range of products to achieve a target Margin based on sales volume, cost and retail.
            /// May be cases where a product could not adhere to min or target margin and are noted in the return values pricing exceptions.
            /// </summary>
            public const string CustomerPricingForTargetMargin = $"{Base}/{nameof(Pricing)}/CustomerPricingForTargetMargin";
        }
        public static class Net
        {
            /// <summary>
            /// Returns net price from the given cost and markup
            /// </summary>
            public const string GetFromCostMarkup = $"{Base}/{nameof(Net)}/FromCostMarkup";
            /// <summary>
            /// Returns net price from the given cost and margin
            /// </summary>
            public const string GetFromCostMargin = $"{Base}/{nameof(Net)}/FromCostMargin";
            /// <summary>
            /// Returns net price from the given retail or normal sell price after a discount is applied
            /// </summary>
            public const string GetFromRetailDiscount = $"{Base}/{nameof(Net)}/FromRetailDiscount";
        }
        public static class Retail
        {
            /// <summary>
            /// returns the retail or sell price from the net value and discount applied
            /// </summary>
            public const string GetFromNetDiscount = $"{Base}/{nameof(Retail)}/FromNetDiscount";
        }
        public static class Margin
        {
            /// <summary>
            /// Returns the margin dollars from the cost and net price
            /// </summary>
            public const string GetDollarFromCostNet = $"{Base}/{nameof(Margin)}/DollarFromCostNet";
            /// <summary>
            /// Returns the margin percent from the cost, retail or sell prices and discount applied
            /// </summary>
            public const string GetPercentFromCostRetailDiscount = $"{Base}/{nameof(Margin)}/PercentFromCostRetailDiscount";
            /// <summary>
            /// Returns the margin percent from the cost, and net price
            /// </summary>
            public const string GetPercentFromCostNet = $"{Base}/{nameof(Margin)}/PercentFromCostNet";
            /// <summary>
            /// Returns the margin dollars from the cost and markup
            /// </summary>
            public const string GetFromCostMarkup = $"{Base}/{nameof(Margin)}/FromCostMarkup";
            /// <summary>
            /// Returns the margin dollars from the net price and markup
            /// </summary>
            public const string GetFromNetMarkup = $"{Base}/{nameof(Margin)}/FromNetMarkup";
            /// <summary>
            /// Returns the margin percent from a markup percent
            /// </summary>
            public const string GetFromMarkup = $"{Base}/{nameof(Margin)}/FromMarkup";
        }
        public static class Cost
        {
            /// <summary>
            /// Returns the cost given the net and markup
            /// </summary>
            public const string GetFromNetMarkup = $"{Base}/{nameof(Cost)}/FromNetMarkup";
            /// <summary>
            /// Returns the cost given the net and margin
            /// </summary>
            public const string GetFromNetMargin = $"{Base}/{nameof(Cost)}/FromNetMargin";
        }
        public static class Markup
        {
            /// <summary>
            /// Returns the markup percent from the cost, and net price
            /// </summary>
            public const string GetFromCostNet = $"{Base}/{nameof(Markup)}/FromCostNet";
            /// <summary>
            /// Returns the markup percent from the net price and margin percent
            /// </summary>
            public const string GetFromNetMargin = $"{Base}/{nameof(Markup)}/FromNetMargin";
            /// <summary>
            /// Returns the markup percent from a margin percent
            /// </summary>
            public const string GetFromMargin = $"{Base}/{nameof(Markup)}/FromMargin";
        }
    }
}
