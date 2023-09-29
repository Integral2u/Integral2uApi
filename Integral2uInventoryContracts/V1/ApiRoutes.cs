using Integral2uInventoryContracts.V1.Requests;

namespace Integral2uInventoryContracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = $"{Root}/{Version}";
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
            /// StockTurn is how many times months it takes to sell though the value of inventory.
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
            /// Using <see cref="GetWeightedUsage"/> this method will look at months prior to last to determin
            /// which range of months is best to use to forcast the next months based on distanced from used months compared to last month,
            /// The usage usinging the most recent month is the computed.
            /// </summary>
            public const string GetBestCaseWeightedUsage = $"{Base}/{nameof(Forecasting)}/BestCaseWeightedUsage";
            /// <summary>
            /// Like <see cref="GetBestCaseWeightedUsage"/> this method will do the same but ustilized various other forcatsing methods
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
    }
}