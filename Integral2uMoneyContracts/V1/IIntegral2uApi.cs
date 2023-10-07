using Integral2uMoneyContracts.V1.Requests;
using static Integral2uMoneyContracts.V1.ApiRoutes;

namespace Integral2uMoneyContracts.V1
{
    /// <summary>
    /// Inherited by <see cref="Integral2uHttpApi"/> and <see cref="Integral2uRestApi"/>
    /// Example: var rest = new Integral2uRestApi("[Your RapidApi Key Here]") as IIntegral2uApi;
    /// </summary>
    public interface IIntegral2uApi: Integral2uCommon.IBaseIntegral2uApi
    {
        #region Discount
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double DiscountFromRetailNet(double retail, double net) => DiscountFromRetailNet(new DiscountFromRetailNet(retail, net));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double DiscountFromRetailNet(DiscountFromRetailNet p) => Post(Discount.GetFromRetailNet, p);
        #endregion
        #region Net
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double NetFromCostMarkup(double cost, double markup) => NetFromCostMarkup(new NetFromCostMarkup(cost, markup));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double NetFromCostMarkup(NetFromCostMarkup p) => Post(Net.GetFromCostMarkup, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double NetFromCostMargin(double cost, double margin) => NetFromCostMargin(new NetFromCostMargin(cost, margin));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double NetFromCostMargin(NetFromCostMargin p) => Post(Net.GetFromCostMargin, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double NetFromRetailDiscount(double retail, double discount) => NetFromRetailDiscount(new NetFromRetailDiscount(retail, discount));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double NetFromRetailDiscount(NetFromRetailDiscount p) => Post(Net.GetFromRetailDiscount, p);
        #endregion
        #region Retail
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double RetailFromNetDiscount(double net, double discount) => RetailFromNetDiscount(new RetailFromNetDiscount(net, discount));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double RetailFromNetDiscount(RetailFromNetDiscount p) => Post(Retail.GetFromNetDiscount, p);
        #endregion
        #region Margin
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginDollarFromCostNet(double cost, double net) => MarginDollarFromCostNet(new MarginDollarFromCostNet(cost, net));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginDollarFromCostNet(MarginDollarFromCostNet p) => Post(Margin.GetDollarFromCostNet, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginPercentFromCostRetailDiscount(double cost, double retail, double discount) => MarginPercentFromCostRetailDiscount(new MarginPercentFromCostRetailDiscount(cost, retail, discount));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginPercentFromCostRetailDiscount(MarginPercentFromCostRetailDiscount p) => Post(Margin.GetPercentFromCostRetailDiscount, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginPercentFromCostNet(double cost, double net) => MarginPercentFromCostNet(new MarginPercentFromCostNet(cost, net));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginPercentFromCostNet(MarginPercentFromCostNet p) => Post(Margin.GetPercentFromCostNet, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginFromCostMarkup(double cost, double markup) => MarginFromCostMarkup(new MarginFromCostMarkup(cost, markup));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginFromCostMarkup(MarginFromCostMarkup p) => Post(Margin.GetFromMarkup, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginFromNetMarkup(double net, double markup) => MarginFromNetMarkup(new MarginFromNetMarkup(net, markup));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginFromNetMarkup(MarginFromNetMarkup p) => Post(Margin.GetFromNetMarkup, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarginFromMarkup(double markup) => MarginFromMarkup(new MarkupPercent(markup));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>        
        public double MarginFromMarkup(MarkupPercent p) => Post(Margin.GetFromMarkup, p);
        #endregion
        #region Cost
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double CostFromNetMarkup(double net, double markup) => CostFromNetMarkup(new CostFromNetMarkup(net, markup));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double CostFromNetMarkup(CostFromNetMarkup p) => Post(Cost.GetFromNetMarkup, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public const string GetFromNetMargin = $"{Base}/{nameof(Cost)}/FromNetMargin";
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double CostFromNetMargin(double net, double margin) => CostFromNetMargin(new CostFromNetMargin(net, margin));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double CostFromNetMargin(CostFromNetMargin p) => Post(Cost.GetFromNetMargin, p);
        #endregion
        #region Markup
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarkupFromCostNet(double cost, double net) => MarkupFromCostNet(new MarkupFromCostNet(cost, net));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarkupFromCostNet(MarkupFromCostNet p) => Post(Markup.GetFromCostNet, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarkupFromNetMargin(double net, double margin) => MarkupFromNetMargin(new MarkupFromNetMargin(net, margin));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarkupFromNetMargin(MarkupFromNetMargin p) => Post(Markup.GetFromNetMargin, p);
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public const string GetFromMargin = $"{Base}/{nameof(Markup)}/FromMargin";
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarkupFromMargin(double margin) => MarkupFromMargin(new MarginPercent(margin));
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public double MarkupFromMargin(MarginPercent p) => Post(Markup.GetFromMargin, p);
        #endregion
        #region Quotes
        /// <summary>
        /// Refer to <see cref="ApiRoutes"/>
        /// </summary>
        public QuoteLine[]? ReduceQuoteByValue(ReduceQuoteByValue p) => Post<ReduceQuoteByValue, QuoteLine[]>(Pricing.ReduceQuoteByValue, p);
        #endregion
    }

}
