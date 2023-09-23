# Welcome and pleased to meet you.
What’s integral to your business? Simple questions and the answer is usually simple, customers.
No doubt you want to provide your customers with the highest level of service and you need the right tool’s to do so and then you need time.
There are many many options, however no matter what you choose or how much you spend there will not be one that does everything you want or need and more unlikely they work together in a way that doesn't consume your time.
This is where Custom API’s can help to fill in the gaps and provide workable solutions for you.
Integral2u will work toward implementing solutions that can integrate or produce results that can be imported into 3rd party systems.
While we will provide custom API's we also create and distibute our own prebuilt API's on Rapid Hub https://rapidapi.com/user/integral2u

# Current API's'
Money
Easy to use money calculators for planing prices, costs, markups.
Quote repricing by value
Planned Pro+
Customer discount planner to achive margin based on sales


# Quick Example
```
using Integral2uMoneyContracts.V1;

//You rapid API Key should not be made publicly visible
//Search appsettings or environment variables
var rest = new Integral2uRestApi("[Your rapid API Key Here]");
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
```               
