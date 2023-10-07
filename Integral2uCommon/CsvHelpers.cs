using System.Reflection;

namespace Integral2uCommon
{
    public static class CsvHelpers
    {        
        public static List<T> ReadCsvStream<T>(Stream stream, out string[] errors,char delim = ',', Func<string[], T>? mapper = null)
        {
            using var reader = new StreamReader(stream);
            return ReadCsvStream<T>(reader, out errors, delim, mapper);
        }

        public static List<T> ReadCsvStream<T>(StreamReader stream, out string[] errors, char delim = ',', Func<string[], T>? mapper = null)
        {
            var e = new List<string>();
            var records = new List<T>();
            string[]? headers = null;
            mapper ??= CreateMapper<T>(e, out headers);
            if (mapper == null || headers == null || headers.Length==0)
            {
                errors = e.ToArray();
                return records;
            }
            var i = 0;
            var len = headers.Length;
            var order = Enumerable.Range(0, len).ToArray();
            while (!stream.EndOfStream)
            {
                i++;
                var line = stream.ReadLine();
                if (line == null) continue;
                var values = line.Split(delim).Select(p=>p.Trim()).ToArray();
                if (values.Length != len) 
                {
                    e.Add($"Failed to process line {i}:{line}");
                }
                if (i == 1)
                {
                    var hasHeaders = true;
                    //chack if headers exist if so check order
                    foreach(var v in values)
                    {
                        if (!headers.Contains(v, StringComparer.InvariantCultureIgnoreCase))
                        {
                            hasHeaders = false;
                            break;
                        }
                    }
                    if (hasHeaders)
                    {
                        for (int x = 0; x < headers.Length; x++)
                        {
                            var v = headers[x];
                            order[x] = Array.FindIndex(values,(p)=>p.Equals(v, StringComparison.InvariantCultureIgnoreCase));
                        }
                        continue;
                    }                                       
                }
                var o = mapper.Invoke(OrderValues(values,order));
                if(o == null) 
                {
                    e.Add($"Failed to process line {i}:{line}");
                }
                records.Add(o);
            }
            errors = e.ToArray();
            return records;
        }

        private static string[] OrderValues(string[] values, int[] order)
        {
            var ret = new string[values.Length];
            for (int i = 0; i < order.Length; i++)
            {
                ret[i] = values[order[i]];
            }
            return ret;
        }

        private static Func<string[], T>? CreateMapper<T>(List<string> e, out string[] headers)
        {
            headers = Array.Empty<string>();
            var ctors = typeof(T).GetConstructors();
            if (ctors.Length != 1) { e.Add($"Expected 1 Constructor found {ctors.Length}"); };
            var ctor = ctors[0];
            ParameterInfo[] paramArray = ctor.GetParameters();
            if (paramArray == null || paramArray.Length == 0)
            {
                e.Add($"No Parameters found");                
                return null;
            };
            var converterList = new List<(int index, string name, Func<string, object?> convert)>();
            for (int i = 0; i < paramArray.Length; i++)
            {
                ParameterInfo? param = paramArray[i];
                if (param.ParameterType.GetInterface(nameof(IConvertible))==null)
                {
                    e.Add($"{param.Name} fails to implement IConvertible");
                    continue;
                }
                if (string.IsNullOrWhiteSpace(param.Name))
                {
                    e.Add($"Parameter name at {param.Position} is invalid");
                    continue;
                }
                var converter = Convert(param.ParameterType);
                if(converter == null)
                {
                    e.Add($"Unable to create Converter of Parameter at {param.Position}");
                    continue;
                }
                converterList.Add(new(param.Position, param.Name, converter));
            }
            if (converterList.Count != paramArray.Length)
            {
                e.Add($"Converter Count Parameter count do not match");
            }
            if (e.Count > 0) return null;
            headers = converterList.OrderBy((p) => p.index).Select((p) => p.name).ToArray();
            var mapper = new Func<string[], T?>((s) => 
            {
                var converters = converterList.OrderBy((p) => p.index).Select((p) => p.convert).ToArray();
                if (converters == null) return default;
                var obs = new List<object>();
                for (int i = 0; i < s.Length; i++)
                {
                    var o = converters[i](s[i]);
                    if (o == null) return default;
                    obs.Add(o);
                }
                var inst = Activator.CreateInstance(typeof(T), obs.ToArray()) ?? default;
                if (inst == null) return default;
                var ret = (T)inst;
                return (T) ret?? default;
            });
            
            return (Func<string[], T>)mapper;
        }

        private static Func<string, object?>? Convert(Type parameterType)
        {
            var converter = new Func<string, object?>((o) =>
            {
                var defaultType = parameterType.IsValueType ? Activator.CreateInstance(parameterType) : parameterType.Equals(typeof(string))? string.Empty:null;
                if (defaultType == null) return null;
                if (defaultType is not IConvertible p) return null;
                var tc = p.GetTypeCode();
                if (tc == TypeCode.DBNull || tc == TypeCode.Empty || tc == TypeCode.Object) return null;
                return tc switch
                {
                    TypeCode.Boolean => Boolean.TryParse(o, out bool bor) ? bor : null,
                    TypeCode.Char => Char.TryParse(o, out char cr) ? cr : null,
                    TypeCode.SByte => SByte.TryParse(o, out sbyte sbr) ? sbr : null,
                    TypeCode.Byte => Byte.TryParse(o, out byte br) ? br : null,
                    TypeCode.Int16 => Int16.TryParse(o, out short i16) ? i16 : null,
                    TypeCode.UInt16 => UInt16.TryParse(o, out ushort ui16) ? ui16 : null,
                    TypeCode.Int32 => Int32.TryParse(o, out int i32) ? i32 : null,
                    TypeCode.UInt32 => UInt32.TryParse(o, out uint ui32) ? ui32 : null,
                    TypeCode.Int64 => Int64.TryParse(o, out long l64) ? l64 : null,
                    TypeCode.UInt64 => UInt64.TryParse(o, out ulong ul64) ? ul64 : null,
                    TypeCode.Single => Single.TryParse(o, out float s) ? s : null,
                    TypeCode.Double => Double.TryParse(o, out double d) ? d : null,
                    TypeCode.Decimal => Decimal.TryParse(o, out decimal de) ? de : null,
                    TypeCode.DateTime => DateTime.TryParse(o, out DateTime dt) ? dt : null,
                    TypeCode.String => o,
                    _ => null,//Empty, Object, DBNull
                };
            });
            return converter;
        }
    }
}
