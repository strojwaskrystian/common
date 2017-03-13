using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sk.common.Helper
{
    public class EnumHelper
    {
        public static T Parse<T>(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }

        public static bool TryParse<T>(string input, out T ret) where T : struct
        {
            return Enum.TryParse<T>(input, true,  out ret);
        }
    }
}
