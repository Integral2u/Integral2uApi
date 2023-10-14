    namespace Integral2uInventoryContracts.V1
{
    public static class MoneyLimits
    {
        /// <summary>
        /// Limits defined for bulk record processing per subscription level.  
        /// These are set in API overriding will not change limits.
        /// </summary>
        public static class QuoteReprice
        {
            public const int QuoteRepriceBasic = 10;
            public const int QuoteRepricePro = 100;
            public const int QuoteRepriceUltra = 500;
            public const int QuoteRepriceMega = 1000;
        }
        /// <summary>
        /// Limits defined for bulk record processing per subscription level.       
        /// These are set in API overriding will not change limits.
        /// </summary>
        public static class CustomerPricing
        {
            public const int CustomerPricingBasic = QuoteReprice.QuoteRepriceBasic;
            public const int CustomerPricingPro = QuoteReprice.QuoteRepricePro;
            public const int CustomerPricingUltra = QuoteReprice.QuoteRepriceUltra;
            public const int CustomerPricingMega = QuoteReprice.QuoteRepriceMega;
        }
    }
}
