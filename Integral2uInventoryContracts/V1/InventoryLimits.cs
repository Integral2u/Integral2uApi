    namespace Integral2uInventoryContracts.V1
{
    public static class InventoryLimits
    {
        /// <summary>
        /// Limits defined for bulk record processing per subscription level.  
        /// These are set in API overriding will not change limits.
        /// </summary>
        public static class MinMax
        {
            public const int MinMaxMultiBasic = 1;
            public const int MinMaxMultiPro = 50;
            public const int MinMaxMultiUltra = 250;
            public const int MinMaxMultiMega = 500;
        }
        /// <summary>
        /// Limits defined for bulk record per subscription level.       
        /// These are set in API overriding will not change limits.
        /// </summary>
        public static class OrderAdvice
        {
            public const int OrderAdviceMultiBasic = MinMax.MinMaxMultiBasic;
            public const int OrderAdviceMultiPro = MinMax.MinMaxMultiPro;
            public const int OrderAdviceMultiUltra = MinMax.MinMaxMultiUltra;
            public const int OrderAdviceMultiMega = MinMax.MinMaxMultiMega;
        }
    }
}
