using System;
using System.Globalization;
using System.Linq;

namespace CommandLineApp
{
    public class StringTransform
    {
        public static string Lowercase(string text)
        {
            return text.ToLower();
        }

        public static string Uppercase(string text)
        {
            return text.ToUpper();
        }

        //Study This!!
        public static string Capitalize(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
