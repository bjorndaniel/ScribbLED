using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace ScribbLED.Common
{
    public static class Utilities
    {
        public static StringContent GetJsonAsStringContent(IEnumerable<object> target)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            sb.Append(target.Select(_ => _.ToString()).Aggregate((a,b) => $"{a},{b}" ));
            sb.Append("]");
            Console.WriteLine(sb.ToString());
            return new StringContent(sb.ToString(), Encoding.UTF8, "application/json");
        }
        //Adapted from https://stackoverflow.com/questions/1450774/splitting-a-string-into-chunks-of-a-certain-size
        public static IEnumerable<string> ChunkSplit(this string str, int chunkSize) =>
            Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
    }

}