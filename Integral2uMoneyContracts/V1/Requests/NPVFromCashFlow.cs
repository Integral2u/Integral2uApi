namespace Integral2uMoneyContracts.V1.Requests
{
    public record NPVFromCashFlow(double CashFlow, double Investment, double DiscountRate, int Periods, double initialOutlay = 0);
}
