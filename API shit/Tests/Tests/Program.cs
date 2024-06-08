using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long unixTimeStamp = 1616400000; // Example Unix timestamp (change this to your Unix timestamp)
            DateTime utcDateTime = UnixTimeStampToUtcDateTime(unixTimeStamp);
            Console.WriteLine($"UTC Time: {utcDateTime}");
        }
        public static DateTime UnixTimeStampToUtcDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp);
            return dateTimeOffset.UtcDateTime;
        }
    }
}
