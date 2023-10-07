namespace Integral2uInventoryContracts.V1.Requests
{
    public record UsageMinMaxDaysMultiple(ProductUsage[] ProductUsage, double MinDays, double MaxDays, double AbsoluteMin = 0.0, double AbsoluteMax = 0.0);
}
