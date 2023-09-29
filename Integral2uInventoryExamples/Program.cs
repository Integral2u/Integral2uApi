using Integral2uInventoryContracts.V1;

//You rapid API Key should not be made publicly visible
//Search appsettings or environment variables
var rest = new Integral2uRestApi("[Your RapidApi Key Here]") as IIntegral2uApi;
var restResult = rest.WeightedUsage(new double[] { 8, 4, 5 });
Console.Out.WriteLine(restResult); //~6.16666

Console.In.ReadLine();