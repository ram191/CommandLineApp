using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandLineApp
{
    public class Arithmetic
    {
        public static double DoArithmetic(List<string> inputdata, string arithmetic)
        {
            double total;

            var nums = new List<int>();
            foreach (var file in inputdata)
            {
                var num = Convert.ToInt32(file);
                nums.Add(num);
            }

            total = nums[0];
            for (int x = 1; x < nums.Count(); x++)
            {
                switch (arithmetic)
                {
                    case "add":
                        total += nums[x];
                        break;
                    case "substract":
                        total -= nums[x];
                        break;
                    case "multiply":
                        total *= nums[x];
                        break;
                    case "divide":
                        total /= nums[x];
                        break;
                }
            }
            return total;
        }
    }
}
