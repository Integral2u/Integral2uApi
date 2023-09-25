namespace Integral2uCommon
{
    public interface IIntegral2uApi
    {
        public double Post<Value>(string path, Value value);
        public Result? Post<Value, Result>(string path, Value value);
    }
}
