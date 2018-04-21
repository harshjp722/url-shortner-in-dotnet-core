using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortnerDotnetCore.Repository
{
    public class Base62EncodeDecode
    {
        private static readonly string allCodeCharString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789";
        private static readonly long baseNumber = allCodeCharString.Length;

        public static string Encode(long i)
        {
            if (i == 0) return allCodeCharString[0].ToString();

            var s = string.Empty;
            while (i > 0)
            {
                s += allCodeCharString[Convert.ToInt16(i % baseNumber)];
                i = i / baseNumber;
            }
            return string.Join(string.Empty, s.Reverse());
        }

        public static long Decode(string s)
        {
            long i = 0;
            foreach (var c in s)
            {
                i = (i * baseNumber) + allCodeCharString.IndexOf(c);
            }
            return i;
        }
    }
}
