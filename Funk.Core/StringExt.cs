using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funk.Core
{
    public static class StringExt
    {
        public static string Truncate(this string value, int length)
        {
            length = Math.Min(length, value.Length);
            value = value.Substring(0, length);
            return value + "..";
        }
    }
}
