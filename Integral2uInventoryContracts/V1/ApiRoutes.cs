namespace Integral2uInventoryContracts.V1
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
        public static class Basic
        {
            /// <summary>
            /// Returns the cost of goods sold given Revenue and Margin %
            /// </summary>
            public const string GetCostOfGoodsSoldFromMarginPercent = $"{Base}/{nameof(Basic)}/CostOfGoodsSoldFromMarginPercent";
            /// <summary>
            /// Returns the cost of goods sold given Revenue and Margin
            /// </summary>
            public const string GetCostOfGoodsSoldFromMargin = $"{Base}/{nameof(Basic)}/CostOfGoodsSoldFromMargin";
        }
        public static class KPI
        {
            /// <summary>
            /// StockTurn is how many times a months it takes to sell though the value of inventory.
            /// Lower is better.
            /// </summary>
            public const string GetStockTurn = $"{Base}/{nameof(KPI)}/StockTurn";
            /// <summary>
            /// Turnover is the ratio of good sold divide by inventory commonly average inverntory.
            /// The higher the better.
            /// </summary>
            public const string GetTurnover = $"{Base}/{nameof(KPI)}/Turnover";
            /// <summary>
            /// Returns how many Days of Inventory(DOI) based on inventory and Cost of Goods Sold(GOGS).
            /// </summary>
            public const string GetDaysOfInventory = $"{Base}/{nameof(KPI)}/DaysOfInventory";
        }
        public static class Conversions
        {
            /// <summary>
            /// Converts Turnover to Days of Inventory(DOI)
            /// </summary>
            public const string GetTurnoverToDOI = $"{Base}/{nameof(Conversions)}/TurnoverToDOI";
            /// <summary>
            /// Converts StockTurn to Days of Inventory(DOI)
            /// </summary>
            public const string GetStockTurnToDOI = $"{Base}/{nameof(Conversions)}/StockTurnToDOI";
            /// <summary>
            /// Converts Days of Inventory(DOI) to Turnover
            /// </summary>
            public const string GetTurnoverFromDOI = $"{Base}/{nameof(Conversions)}/TurnoverFromDOI";
            /// <summary>
            /// Converts Days of Inventory(DOI) to StockTurn
            /// </summary>
            public const string GetStockTurnFromDOI = $"{Base}/{nameof(Conversions)}/StockTurnFromDOI";
        }
        public static class Forecasting
        {
            /// <summary>
            /// Returns the weighted usage of a an item give the sales per month where the closest 
            /// month has the most importance.  
            /// Example: Given 3 months sales {8,4,5}
            /// the result would be ((8*3)+(4*2)+(5*1))/(3+2+1) = 6.1666...7
            /// </summary>
            public const string GetWeightedUsage = $"{Base}/{nameof(Forecasting)}/WeightedUsage";
            /// <summary>
            /// Using <see cref="GetWeightedUsage"/> this method will look at months prior to last to determine
            /// which range of months is best to use to forecast the next months based on distanced from used months compared to last month,
            /// The usage using the most recent month is the computed.
            /// </summary>
            public const string GetBestCaseWeightedUsage = $"{Base}/{nameof(Forecasting)}/BestCaseWeightedUsage";
            /// <summary>
            /// Like <see cref="GetBestCaseWeightedUsage"/> this method will do the same but utilize various other forecasting methods
            /// to pick the best suited algorithm and parameters.
            /// </summary>
            public const string GetBestCaseUsage = $"{Base}/{nameof(Forecasting)}/BestCaseUsage";
        }

        //The four Methods below provide a means of calculating any one of each providing the other three.
        public static class Relational
        {
            /// <summary>
            /// Given Revenue, Margin % and StockTurn you can determine the Inventory 
            /// </summary>
            public const string GetInventoryValueFrom = $"{Base}/{nameof(Relational)}/InventoryValue";
            /// <summary>
            /// Given Inventory, Revenue and StockTurn you can determine the Margin % 
            /// </summary>
            public const string GetMarginPercentFrom = $"{Base}/{nameof(Relational)}/MarginPercent";
            /// <summary>
            /// Given Inventory, StockTurn and Margin % you can determine the Revenue 
            /// </summary>
            public const string GetRevenueFrom = $"{Base}/{nameof(Relational)}/Revenue";
            /// <summary>
            /// Given Inventory, Revenue and Margin % you can determine the StockTurn 
            /// </summary>
            public const string GetStockTurnFrom = $"{Base}/{nameof(Relational)}/StockTurn";
        }
        public static class Stock
        {
            /// <summary>
            /// MinMax is used to determine the minimum stock and maximum stock to hold.
            /// Orders would be processed when stock reaches the minimum and orders upto the maximum
            /// </summary>
            public const string MinMax = $"{Base}/{nameof(Stock)}/MinMax";

            /// <summary>
            /// MinMaxMulti allows for multiple products to have their <see cref="MinMax"/> calculated.
            /// Refer to https://rapidapi.com/integral2u/api/integral2uinventory1 for qty and rate limits.
            /// </summary>
            public const string MinMaxMulti = $"{Base}/{nameof(Stock)}/MinMaxMulti";
            /// <summary>
            /// Advises quantity to order given potential stock availability SOH-SO+PO the minimum and maximum stock and pack size
            /// </summary>
            public const string StockOrderAdvice = $"{Base}/{nameof(Stock)}/StockOrderAdvice";
            /// <summary>
            /// StockOrderAdviceMulti allows for multiple products to have their <see cref="StockOrderAdvice"/> calculated.
            /// Refer to https://rapidapi.com/integral2u/api/integral2uinventory1 for qty and rate limits.
            /// </summary>
            public const string StockOrderAdviceMulti = $"{Base}/{nameof(Stock)}/StockOrderAdviceMulti";
        }
    }
}