namespace Integral2uCommon
{
    /// <summary>
    /// Expected to implemented by abstract classs to proved http and rest posts. 
    /// API specifi Interfaces to implement this so can us default interface helper methods
    /// Example: var rest = new Integral2uRestApi("[Your RapidApi Key Here]") as IIntegral2uApi;
    /// </summary>
    public interface IBaseIntegral2uApi
    {
        /// <summary>
        /// Post to the API path with a a type. Primative double return only.
        /// </summary>
        /// <typeparam name="Value">The type of value(Request) being sent</typeparam>
        /// <param name="path">API Endpoint</param>
        /// <param name="value">The value(Request)</param>
        /// <returns>The Result</returns>
        public double Post<Value>(string path, Value value);
        /// <summary>
        /// Post to the API path with a a type.
        /// </summary>
        /// <typeparam name="Value">The type of value(Request) being sent</typeparam>
        /// <typeparam name="Result">The expected return type</typeparam>
        /// <param name="path">API Endpoint</param>
        /// <param name="value">The value(Request)</param>
        /// <returns>The Result</returns>
        public Result? Post<Value, Result>(string path, Value value);
    }
}
