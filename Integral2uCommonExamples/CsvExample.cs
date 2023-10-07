using Integral2uCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral2uCommonExamples
{       
    public class CsvExample
    {
        public record TestType(string Name, double ValueA, double ValueB);
        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public bool Pass = true;
        public CsvExample()
        {
            Example1();
            Example2();
            Example3();
            Example4();
        }
        /// <summary>
        /// Headers in order
        /// </summary>
        private void Example1()
        {
            using var stream = GenerateStreamFromString("Name,ValueA,ValueB \n Bob,1,2.2");
            var records = CsvHelpers.ReadCsvStream<TestType>(stream, out string[] errors);
            if (errors.Any()) Pass = false;
            foreach (var item in records)
            {
                Console.Out.WriteLine(item.ToString());
            }
            
        }
        /// <summary>
        /// Headers out of order
        /// </summary>
        private void Example2()
        {
            using var stream = GenerateStreamFromString("Name,ValueB,ValueA \n Bob,2.2,1");
            var records = CsvHelpers.ReadCsvStream<TestType>(stream, out string[] errors);
            if (errors.Any()) Pass = false;
            foreach (var item in records)
            {
                Console.Out.WriteLine(item.ToString());
            }
        }
        /// <summary>
        /// No Headers
        /// </summary>
        private void Example3()
        {
            using var stream = GenerateStreamFromString("Bob,1,2.2");
            var records = CsvHelpers.ReadCsvStream<TestType>(stream, out string[] errors);
            if (errors.Any()) Pass = false;
            foreach (var item in records)
            {
                Console.Out.WriteLine(item.ToString());
            }
        }
        /// <summary>
        /// Fail
        /// </summary>
        private void Example4()
        {
            using var stream = GenerateStreamFromString("Bob,X,2.2");
            var records = CsvHelpers.ReadCsvStream<TestType>(stream, out string[] errors);
            if (errors.Any()) Pass = true;
            foreach (var error in errors)
            {
                Console.Out.WriteLine(error.ToString());
            }
        }
    }
}
