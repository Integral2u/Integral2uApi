using Integral2uMoneyContracts.V1.Requests;
using static Integral2uMoneyContracts.V1.ApiRoutes;

namespace Integral2uMoneyContracts.V1
{
    public interface IIntegral2uApi: Integral2uCommon.IIntegral2uApi
    {
        public double DiscountFromRetailNet(double retail, double net) => DiscountFromRetailNet(new DiscountFromRetailNet(retail, net));
        public double DiscountFromRetailNet(DiscountFromRetailNet p) => Post(Discount.GetFromRetailNet, p);

        public double NetFromCostMarkup(double cost, double markup) => NetFromCostMarkup(new NetFromCostMarkup(cost, markup));
        public double NetFromCostMarkup(NetFromCostMarkup p) => Post(Net.GetFromCostMarkup, p);
        public double NetFromCostMargin(double cost, double margin) => NetFromCostMargin(new NetFromCostMargin(cost, margin));
        public double NetFromCostMargin(NetFromCostMargin p) => Post(Net.GetFromCostMargin, p);
        public double NetFromRetailDiscount(double retail, double discount) => NetFromRetailDiscount(new NetFromRetailDiscount(retail, discount));
        public double NetFromRetailDiscount(NetFromRetailDiscount p) => Post(Net.GetFromRetailDiscount, p);

        public double RetailFromNetDiscount(double net, double discount) => RetailFromNetDiscount(new RetailFromNetDiscount(net, discount));
        public double RetailFromNetDiscount(RetailFromNetDiscount p) => Post(Retail.GetFromNetDiscount, p);

        public double MarginDollarFromCostNet(double cost, double net) => MarginDollarFromCostNet(new MarginDollarFromCostNet(cost, net));
        public double MarginDollarFromCostNet(MarginDollarFromCostNet p) => Post(Margin.GetDollarFromCostNet, p);

        public double MarginPercentFromCostRetailDiscount(double cost, double retail, double discount) => MarginPercentFromCostRetailDiscount(new MarginPercentFromCostRetailDiscount(cost, retail, discount));
        public double MarginPercentFromCostRetailDiscount(MarginPercentFromCostRetailDiscount p) => Post(Margin.GetPercentFromCostRetailDiscount, p);

        public double MarginPercentFromCostNet(double cost, double net) => MarginPercentFromCostNet(new MarginPercentFromCostNet(cost, net));
        public double MarginPercentFromCostNet(MarginPercentFromCostNet p) => Post(Margin.GetPercentFromCostNet, p);

        public double MarginFromCostMarkup(double cost, double markup) => MarginFromCostMarkup(new MarginFromCostMarkup(cost, markup));
        public double MarginFromCostMarkup(MarginFromCostMarkup p) => Post(Margin.GetFromMarkup, p);

        public double MarginFromNetMarkup(double net, double markup) => MarginFromNetMarkup(new MarginFromNetMarkup(net, markup));
        public double MarginFromNetMarkup(MarginFromNetMarkup p) => Post(Margin.GetFromNetMarkup, p);

        public double MarginFromMarkup(double markup) => MarginFromMarkup(new MarkupPercent(markup));
        public double MarginFromMarkup(MarkupPercent p) => Post(Margin.GetFromMarkup, p);

        public double CostFromNetMarkup(double net, double markup) => CostFromNetMarkup(new CostFromNetMarkup(net, markup));
        public double CostFromNetMarkup(CostFromNetMarkup p) => Post(Cost.GetFromNetMarkup, p);

        public const string GetFromNetMargin = $"{Base}/{nameof(Cost)}/FromNetMargin";
        public double CostFromNetMargin(double net, double margin) => CostFromNetMargin(new CostFromNetMargin(net, margin));
        public double CostFromNetMargin(CostFromNetMargin p) => Post(Cost.GetFromNetMargin, p);

        public double MarkupFromCostNet(double cost, double net) => MarkupFromCostNet(new MarkupFromCostNet(cost, net));
        public double MarkupFromCostNet(MarkupFromCostNet p) => Post(Markup.GetFromCostNet, p);
        public double MarkupFromNetMargin(double net, double margin) => MarkupFromNetMargin(new MarkupFromNetMargin(net, margin));
        public double MarkupFromNetMargin(MarkupFromNetMargin p) => Post(Markup.GetFromNetMargin, p);

        public const string GetFromMargin = $"{Base}/{nameof(Markup)}/FromMargin";
        public double MarkupFromMargin(double margin) => MarkupFromMargin(new MarginPercent(margin));
        public double MarkupFromMargin(MarginPercent p) => Post(Markup.GetFromMargin, p);

        public QuoteLine[]? ReduceQuoteByValue(ReduceQuoteByValue p) => Post<ReduceQuoteByValue, QuoteLine[]>(Pricing.ReduceQuoteByValue, p);

    }

}
