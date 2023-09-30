# Welcome and pleased to meet you.
What’s integral to your business? Simple questions and the answer is usually simple, customers.
No doubt you want to provide your customers with the highest level of service and you need the right tool’s to do so and then you need time.
There are many many options, however no matter what you choose or how much you spend there will not be one that does everything you want or need and more unlikely they work together in a way that doesn't consume your time.
This is where Custom API’s can help to fill in the gaps and provide workable solutions for you.
Integral2u will work toward implementing solutions that can integrate or produce results that can be imported into 3rd party systems.
While we will provide custom API's we also create and distibute our own prebuilt API's on Rapid Hub https://rapidapi.com/user/integral2u

# Current API's'
Money
Easy to use Enterprise resource planning (ERP) tools for planing prices, costs, markups and dealing with money.
https://www.nuget.org/packages/Integral2uMoneyContracts/

Inventory
Inventory proveide the inventory management Enterprise Resource Managment(ERP) tools to aid in planning and achieving optimal inventory.  Great for determining and forcasting inventory requirements.
https://www.nuget.org/packages/Integral2uInventoryContracts/

# Quick Example
```
using Integral2uMoneyContracts.V1;

//You rapid API Key should not be made publicly visible
//Search appsettings or environment variables
var rest = new Integral2uRestApi("[Your rapid API Key Here]") as IIntegral2uApi; 
var restResult = rest.DiscountFromRetailNet(1.0, 0.5);
Console.Out.WriteLine(restResult);

Console.Out.WriteLine(rest.RetailFromNetDiscount(0.5, restResult));

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
```               
