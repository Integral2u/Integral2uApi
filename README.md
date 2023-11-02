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
Inventory provides inventory management Enterprise Resource Managment(ERP) tools to aid in planning and achieving optimal inventory.  Great for determining and forcasting inventory requirements.
https://www.nuget.org/packages/Integral2uInventoryContracts/

Sales Tax
Easy to use Sales Tax information and Calculators for multiple countries  Great for determining and forcasting inventory requirements.
https://www.nuget.org/packages/Integral2uSalesTaxContracts/

# Quick Example
```
using Integral2uSalesTaxContracts.V1;
using Integral2uSalesTaxContracts.V1.Requests;

//You rapid API Key should not be made publicly visible
//Search appsettings or environment variables
//var client = new Integral2uHttpApi("[Your RapidApi Key Here]") as IIntegral2uApi;
var client = new Integral2uRestApi("[Your RapidApi Key Here]") as IIntegral2uApi;
var countryCodes = client.CountryCodes();
foreach(var code in countryCodes??Array.Empty<string>()) 
    Console.Out.WriteLine(code);
var provences = client.StateProvenceFor(new CountryCodeRequest("CAN"));
foreach (var provence in provences ?? Array.Empty<string>())
    Console.Out.WriteLine(provence);

var VAT = client.RecordFor(new SalesTaxRecordRequest("usa", "1001", string.Empty));
Console.Out.WriteLine(VAT.StandardRate);

Console.In.ReadLine();
```
