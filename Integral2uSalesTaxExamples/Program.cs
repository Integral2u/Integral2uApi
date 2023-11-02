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