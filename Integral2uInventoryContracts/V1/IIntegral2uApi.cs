using Integral2uCommon;
using Integral2uInventoryContracts.V1.Data;
using Integral2uInventoryContracts.V1.Requests;
using Integral2uInventoryContracts.V1.Response;
using System.Drawing;
using static Integral2uInventoryContracts.V1.ApiRoutes;

namespace Integral2uInventoryContracts.V1
{
    /// <summary>
    /// Inherited by <see cref="Integral2uHttpApi"/> and <see cref="Integral2uRestApi"/>
    /// Example: var rest = new Integral2uRestApi("[Your RapidApi Key Here]") as IIntegral2uApi;
    /// </summary>
    public interface IIntegral2uApi : Integral2uCommon.IBaseIntegral2uApi
    {
        #region Helpers
        public ApiUserSubscription UserSubscription() => Post<ApiUserSubscription>(Helpers.GetUserSubscription);
        //Usefull when you need to turn Transaction QTY's to Month Totals.  helper for forcasting functions.
        public double[] AggrigateMonthValueFromDateTimeTransaction((DateTime date, double val)[] transactions)
        {
            var agg = new Dictionary<DateOnly, double>();
            foreach (var (date, val) in transactions)
            {
                var key = new DateOnly(date.Year, date.Month, 1);
                if (!agg.ContainsKey(key)) agg.Add(key, 0);
                agg[key] += val
;
            }
            return agg.OrderByDescending(p => p.Key).Select(p=>p.Value).ToArray();
        }
        #endregion
        #region Basic
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double COGSSoldFromMarginPercent(double revenue, double marginPercent) => COGSSoldFromMarginPercent(new RevenueMarginPercent(revenue, marginPercent));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double COGSSoldFromMarginPercent(RevenueMarginPercent p) => Post(Basic.GetCostOfGoodsSoldFromMarginPercent, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double COGSFromGoodsSoldFromMargin(double revenue, double margin) => COGSFromGoodsSoldFromMargin(new RevenueMargin(revenue, margin));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double COGSFromGoodsSoldFromMargin(RevenueMargin p) => Post(Basic.GetCostOfGoodsSoldFromMargin, p);
        #endregion
        #region KPI's
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double StockTurnFromInventoryCOGS(double inventory, double cogs) => StockTurnFromInventoryCOGS(new InventoryCOGS(inventory, cogs));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double StockTurnFromInventoryCOGS(InventoryCOGS p) => Post(KPI.GetStockTurn, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double TurnoverFromInventoryCOGS(double inventory, double cogs) => TurnoverFromInventoryCOGS(new InventoryCOGS(inventory, cogs));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double TurnoverFromInventoryCOGS(InventoryCOGS p) => Post(KPI.GetTurnover, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double DOIFromInventoryCOGS(double inventory, double cogs) => DOIFromInventoryCOGS(new InventoryCOGS(inventory, cogs));
        public double DOIFromInventoryCOGS(InventoryCOGS p) => Post(KPI.GetDaysOfInventory, p);
        #endregion
        #region Conversion
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double TurnoverToDOI(double turnover) => TurnoverToDOI(new Turnover(turnover));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double TurnoverToDOI(Turnover p) => Post(Conversions.GetTurnoverToDOI, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double StockTurnToDOI(double stockTurn) => StockTurnToDOI(new StockTurn(stockTurn));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double StockTurnToDOI(StockTurn p) => Post(Conversions.GetStockTurnToDOI, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double TurnoverFromDOI(double doi) => TurnoverFromDOI(new DaysOfInventory(doi));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double TurnoverFromDOI(DaysOfInventory p) => Post(Conversions.GetTurnoverFromDOI, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double StockTurnFromDOI(double doi) => StockTurnFromDOI(new DaysOfInventory(doi));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double StockTurnFromDOI(DaysOfInventory p) => Post(Conversions.GetStockTurnFromDOI, p);
        #endregion
        #region Forecasting
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double WeightedUsage(double[] sales) => WeightedUsage(new ForecastUsing(sales));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double WeightedUsage(ForecastUsing p) => Post(Forecasting.GetWeightedUsage, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public ProductUsage[]? WeightedUsageMulti(ProductForecastUsing[] p) => Post<ProductForecastUsing[], ProductUsage[]>(Forecasting.GetWeightedUsageMulti, p);

        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public ForecastResult? BestCaseWeightedUsage(double[] sales) => BestCaseWeightedUsage(new ForecastUsing(sales));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public ProductForecastResult[]? BestCaseWeightedUsageMulti(ProductForecastUsing[] p) => Post<ProductForecastUsing[], ProductForecastResult[]>(Forecasting.GetBestCaseWeightedUsageMulti, p);

        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public ForecastResult? BestCaseWeightedUsage(ForecastUsing p) => Post<ForecastUsing, ForecastResult>(Forecasting.GetBestCaseWeightedUsage, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public ProductForecastResult[]? BestCaseUsageMulti(ProductForecastUsing[] p) => Post<ProductForecastUsing[], ProductForecastResult[]>(Forecasting.GetBestCaseUsageMulti, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public ForecastResult? BestCaseUsage(double[] sales) => BestCaseUsage(new ForecastUsing(sales));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public ForecastResult? BestCaseUsage(ForecastUsing p) => Post<ForecastUsing, ForecastResult>(Forecasting.GetBestCaseUsage, p);
        #endregion
        #region  Relational
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double InventoryFromRevenueMarginPercentStockTurn(double revenue, double marginPercent, double stockTurn) => InventoryFromRevenueMarginPercentStockTurn(new RevenueMarginPercentStockTurn(revenue, marginPercent, stockTurn));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double InventoryFromRevenueMarginPercentStockTurn(RevenueMarginPercentStockTurn p) => Post(Relational.GetInventoryValueFrom, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginPercentFromInventoryRevenueStockTurn(double inventory, double revenue, double stockTurn) => MarginPercentFromInventoryRevenueStockTurn(new InventoryRevenueStockTurn(inventory, revenue, stockTurn));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginPercentFromInventoryRevenueStockTurn(InventoryRevenueStockTurn p) => Post(Relational.GetMarginPercentFrom, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double RevenueFromInventoryStockTurnMarginPercent(double inventory, double stockTurn, double marginPercent) => RevenueFromInventoryStockTurnMarginPercent(new InventoryStockTurnMarginPercent(inventory, stockTurn, marginPercent));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double RevenueFromInventoryStockTurnMarginPercent(InventoryStockTurnMarginPercent p) => Post(Relational.GetRevenueFrom, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double StockTurnFromInventoryRevenueMarginPercent(double inventory, double revenue, double marginPercent) => StockTurnFromInventoryRevenueMarginPercent(new InventoryRevenueMarginPercent(inventory, revenue, marginPercent));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double StockTurnFromInventoryRevenueMarginPercent(InventoryRevenueMarginPercent p) => Post(Relational.GetStockTurnFrom, p);
        #endregion
        #region Stock
        public MinMaxResult? MinMax(UsageMinMaxDays usageMinMaxDays) => Post<UsageMinMaxDays, MinMaxResult>(Stock.MinMax, usageMinMaxDays);
        public ProductMinMaxResult[]? MinMaxMulti(UsageMinMaxDaysMultiple usageMinMaxDaysMulit) => Post<UsageMinMaxDaysMultiple, ProductMinMaxResult[]>(Stock.MinMaxMulti, usageMinMaxDaysMulit);

        public double StockOrderAdvice(StockLevelData stockLevelData) => Post(Stock.StockOrderAdvice, stockLevelData);
        public ProductOrderQtyResult? StockOrderAdviceMulti(ProductStockLevelData[] productStockLevelData) => Post<ProductStockLevelData[], ProductOrderQtyResult>(Stock.StockOrderAdviceMulti, productStockLevelData);
        #endregion
    }
}
