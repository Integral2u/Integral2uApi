namespace Integral2uInventoryContracts.V1.Requests
{
    public record UsageMinMaxDays(double Usage, double MinDays, double MaxDays, double AbsoluteMin = 0.0, double AbsoluteMax = 0.0);
}
