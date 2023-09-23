namespace Integral2uMoneyContracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = $"{Root}/{Version}";
        public static class Discount
        {
            /// <summary>
            /// Returns the discount applied given the retail and net prices
            /// </summary>
            public const string GetFromRetailNet = $"{Base}/{nameof(Discount)}/FromRetailNet";
        }

        public static class Quote
        {
            /// <summary>
            /// Attempts to reduce a quote by a given value. Decreases all sell until a defined min margin percent or 0% by default
            /// the reduction value is always removed regardless  of sign. Precision is defined most granular decimal place in all sells.
            /// </summary>
            public const string ReduceQuoteByValue = $"{Base}/{nameof(Quote)}/ReduceQuoteByValue";
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
