namespace Integral2uMoneyContracts.V1.Requests
{
    public record NPVFromCashFlows(double[] CashFlows, double Investment, double DiscountRate, double initialOutlay = 0);
}
