using System;
using System.Text.RegularExpressions;

namespace CommandLineApp
{
    public class Palindrome
    {
        public static bool IsPalindrome(string str)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            str = rgx.Replace(str, "");

            int length = str.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (str[i] != str[length - i - 1])
                    return false;
            }
            return true;
        }
    }
}
