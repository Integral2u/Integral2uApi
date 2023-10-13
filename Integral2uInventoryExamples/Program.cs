using Integral2uInventoryContracts.V1;
using Integral2uInventoryContracts.V1.Data;
using Integral2uInventoryContracts.V1.Requests;
using System.Runtime.InteropServices;

//You rapid API Key should not be made publicly visible
//Search appsettings or environment variables
var rest = new Integral2uRestApi("[Your RapidApi Key Here]") as IIntegral2uApi;
var restResult = rest.WeightedUsage(new double[] { 8, 4, 5 });
Console.Out.WriteLine(restResult); //~6.16666

var minMaxInput = new UsageMinMaxDays(1, 1, 365.0 / 12.0, 0.1, 0.9);
var minMax = rest.MinMax(minMaxInput);
var minMaxMulti = rest.MinMaxMulti(
    new UsageMinMaxDaysMultiple(
        new[] { new ProductUsage("SKU1", minMaxInput.Usage) },
        minMaxInput.MinDays,
        minMaxInput.MaxDays,
        minMaxInput.AbsoluteMin,
        minMaxInput.AbsoluteMax));
if (minMax != null && minMaxMulti != null)
    Console.Out.WriteLine(minMax.Min == minMaxMulti[0].Min && minMax.Max == minMaxMulti[0].Max);

var stockLevelDataInput = new StockLevelData(0.5, 1, 2, 0.5);
var order = rest.StockOrderAdvice(stockLevelDataInput);
var orderMulti = rest.StockOrderAdviceMulti(new ProductStockLevelData[]{
    new ProductStockLevelData("SKU1",
    stockLevelDataInput.PotentialAFS,
    stockLevelDataInput.Min,
    stockLevelDataInput.Max,
    stockLevelDataInput.PackSize) });
if (orderMulti != null)
    Console.Out.WriteLine(order == orderMulti.Products[0].Qty);

var aggrigate = rest.AggrigateMonthValueFromDateTimeTransaction(new (DateTime, double)[]
{
    new (new DateTime(2024,2,1),8),
    new (new DateTime(2023,1,1),5),
    new (new DateTime(2023,1,6),5),
    new (new DateTime(2023,12,1),6)
});
Console.Out.WriteLine(aggrigate[0]);// should be 8
Console.Out.WriteLine(aggrigate[1]);// should be 6
Console.Out.WriteLine(aggrigate[2]);// should be 10
Console.In.ReadLine();