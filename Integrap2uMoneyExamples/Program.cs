using Integral2uMoneyContracts.V1;
using Integral2uMoneyContracts.V1.Requests;

//You rapid API Key should not be made publicly visible
//Search appsettings or environment variables
var rest = new Integral2uRestApi("[Your RapidApi Key Here]") as IIntegral2uApi;
var restResult = rest.DiscountFromRetailNet(1.0, 0.5);
Console.Out.WriteLine(restResult);
Console.Out.WriteLine(rest.RetailFromNetDiscount(0.5, restResult));

//You rapid API Key should not be made publicly visible
//Search appsettings or environment variables
var http = new Integral2uHttpApi("[Your RapidApi Key Here]") as IIntegral2uApi;
var httpResult = http.DiscountFromRetailNet(1.0, 0.5);
Console.Out.WriteLine(httpResult);
Console.Out.WriteLine(http.RetailFromNetDiscount(0.5, httpResult));

var margin = http.MarginFromMarkup(0.2);
var markup = http.MarkupFromMargin(margin);

Console.WriteLine($"a markup of of 20% = margin of {Math.Round(margin*100,1)}% and a Margin of {Math.Round(margin*100,1)}% = a markup of {Math.Round(markup*100,2)}% = {Math.Abs(margin-http.MarginFromMarkup(markup))<0.000001}");

var quote = new[] {
                    new QuoteLine("1", 50, 60.00005, 10),
                    new QuoteLine("2", 10, 11, 250),
                    new QuoteLine("3", 10, 11, 250),
                    new QuoteLine("4", 10, 12, 75, 2.0/12.0)
                };
var q = http.ReduceQuoteByValue(new ReduceQuoteByValue(quote, -50));

var c = 0.0;
var s = 0.0;
foreach (var l in q)
{
    Console.Out.WriteLine($"{l.Sku}\t{Math.Round(l.Cost, 4)}\t{Math.Round(l.Sell, 4)}\t{Math.Round(l.Qty, 4)}\t{Math.Round((l.Qty * l.Sell), 4)}");
    c += l.Qty * l.Cost;
    s += l.Qty * l.Sell;
}
var m = s - c;
Console.Out.WriteLine($"{Math.Round(c, 4)}\t{Math.Round(s, 4)}\t{Math.Round(m, 4)}\t{Math.Round(m / s, 4)}");

Console.In.ReadLine();