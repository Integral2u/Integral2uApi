using Integral2uInventoryContracts.V1.Requests;
using Integral2uInventoryContracts.V1.Response;
using static Integral2uInventoryContracts.V1.ApiRoutes;

namespace Integral2uInventoryContracts.V1
{
    public interface IIntegral2uApi : Integral2uCommon.IIntegral2uApi
    {
        // Basic
        public double COGSSoldFromMarginPercent(double revenue, double marginPercent) => COGSSoldFromMarginPercent(new RevenueMarginPercent(revenue, marginPercent));
        public double COGSSoldFromMarginPercent(RevenueMarginPercent p) => Post(Basic.GetCostOfGoodsSoldFromMarginPercent, p);
        public double COGSFromGoodsSoldFromMargin(double revenue, double margin) => COGSFromGoodsSoldFromMargin(new RevenueMargin(revenue, margin));
        public double COGSFromGoodsSoldFromMargin(RevenueMargin p) => Post(Basic.GetCostOfGoodsSoldFromMargin, p);
        // KPI's
        public double StockTurnFromInventoryCOGS(double inventory, double cogs) => StockTurnFromInventoryCOGS(new InventoryCOGS(inventory, cogs));
        public double StockTurnFromInventoryCOGS(InventoryCOGS p) => Post(KPI.GetStockTurn, p);
        public double TurnoverFromInventoryCOGS(double inventory, double cogs) => TurnoverFromInventoryCOGS(new InventoryCOGS(inventory, cogs));
        public double TurnoverFromInventoryCOGS(InventoryCOGS p) => Post(KPI.GetTurnover, p);
        public double DOIFromInventoryCOGS(double inventory, double cogs) => DOIFromInventoryCOGS(new InventoryCOGS(inventory, cogs));
        public double DOIFromInventoryCOGS(InventoryCOGS p) => Post(KPI.GetDaysOfInventory, p);
        // Conversion
        public double TurnoverToDOI(double turnover) => TurnoverToDOI(new Turnover(turnover));
        public double TurnoverToDOI(Turnover p) => Post(Conversions.GetTurnoverToDOI, p);
        public double StockTurnToDOI(double stockTurn) => StockTurnToDOI(new StockTurn(stockTurn));
        public double StockTurnToDOI(StockTurn p) => Post(Conversions.GetStockTurnToDOI, p);
        public double TurnoverFromDOI(double doi) => TurnoverFromDOI(new DaysOfInventory(doi));
        public double TurnoverFromDOI(DaysOfInventory p) => Post(Conversions.GetTurnoverFromDOI, p);
        public double StockTurnFromDOI(double doi) => StockTurnFromDOI(new DaysOfInventory(doi));
        public double StockTurnFromDOI(DaysOfInventory p) => Post(Conversions.GetStockTurnFromDOI, p);
        //Forecasting
        public double WeightedUsage(double[] sales) => WeightedUsage(new ForecastUsing(sales));
        public double WeightedUsage(ForecastUsing p) => Post(Forecasting.GetWeightedUsage, p);
        public ForecastResult? BestCaseWeightedUsage(double[] sales) => BestCaseWeightedUsage(new ForecastUsing(sales));
        public ForecastResult? BestCaseWeightedUsage(ForecastUsing p) => Post<ForecastUsing, ForecastResult>(Forecasting.GetBestCaseWeightedUsage, p);
        public ForecastResult? BestCaseUsage(double[] sales) => BestCaseUsage(new ForecastUsing(sales));
        public ForecastResult? BestCaseUsage(ForecastUsing p) => Post<ForecastUsing, ForecastResult>(Forecasting.GetBestCaseUsage, p);
        //Relational
        public double InventoryFromRevenueMarginPercentStockTurn(double revenue, double marginPercent, double stockTurn) => InventoryFromRevenueMarginPercentStockTurn(new RevenueMarginPercentStockTurn(revenue, marginPercent, stockTurn));
        public double InventoryFromRevenueMarginPercentStockTurn(RevenueMarginPercentStockTurn p) => Post(Relational.GetInventoryValueFrom, p);
        public double MarginPercentFromInventoryRevenueStockTurn(double inventory, double revenue, double stockTurn) => MarginPercentFromInventoryRevenueStockTurn(new InventoryRevenueStockTurn(inventory, revenue, stockTurn));
        public double MarginPercentFromInventoryRevenueStockTurn(InventoryRevenueStockTurn p) => Post(Relational.GetMarginPercentFrom, p);
        public double RevenueFromInventoryStockTurnMarginPercent(double inventory, double stockTurn, double marginPercent) => RevenueFromInventoryStockTurnMarginPercent(new InventoryStockTurnMarginPercent(inventory, stockTurn, marginPercent));
        public double RevenueFromInventoryStockTurnMarginPercent(InventoryStockTurnMarginPercent p) => Post(Relational.GetRevenueFrom, p);
        public double StockTurnFromInventoryRevenueMarginPercent(double inventory, double revenue, double marginPercent) => StockTurnFromInventoryRevenueMarginPercent(new InventoryRevenueMarginPercent(inventory, revenue, marginPercent));
        public double StockTurnFromInventoryRevenueMarginPercent(InventoryRevenueMarginPercent p) => Post(Relational.GetStockTurnFrom, p);
    }
}
