using System;
using System.Collections.Generic;

namespace CommandLineApp
{
    public class Obfuscator
    {
        public static string Obfuscate(string data)
        {
            var newdata = data.ToCharArray();
            List<string> result = new List<string>();

            for(int x = 0; x<newdata.Length-1; x++)
            {
                var i = Convert.ToInt32(data[x]);
                i.ToString();
                result.Add($"&#{i}");
            }

            return String.Join(';', result);
        }
    }
}
