using Integral2uSalesTaxContracts.V1.Requests;
using static Integral2uSalesTaxContracts.V1.ApiRoutes;

namespace Integral2uSalesTaxContracts.V1
{
    /// <summary>
    /// API Endpoint structure
    /// </summary>
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = $"{Root}/{Version}";
        public static class Helpers
        {
            /// <summary>
            /// Gets the APIs user subscription
            /// </summary>
            public const string GetUserSubscription = $"{Base}/{nameof(Helpers)}/UserSubscription";
        }
        public static class SalesTax
        {
            /// <summary>
            /// Gets a List of Available Country Codes
            /// </summary>
            public const string GetCountryCodes = $"{Base}/{nameof(SalesTax)}/CountryCodes";
            /// <summary>
            /// Gets the sales tax record given a <see cref="SalesTaxRecordRequest"/>
            /// United States must provide USA as the Country Code and the 5 digit Zipcode
            /// Canada must provide CAN as the Country Code and the name of the Provence <see cref="GetStateProvenceFor"/>
            /// </summary>
            public const string GetRecordFor = $"{Base}/{nameof(SalesTax)}/RecordFor";

            /// <summary>
            /// Gets available states or provences given a Country Code.
            /// </summary>
            public const string GetStateProvenceFor = $"{Base}/{nameof(SalesTax)}/StateProvenceFor";
            
        }
    }

}
