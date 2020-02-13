using System;
using System.Linq;

namespace CommandLineApp
{
    public class Arithmetic
    {
        public static int Add(params int[] numbers)
        {
            return numbers.Sum();
        }

        public static int Substract(params int[] numbers)
        {
            int total = 0;
            for(int x = 0; x < numbers.Length - 1; x++)
            {
                total -= numbers[x];
            }
            return total;
        }

        public static int Multiply(params int[] numbers)
        {
            int total = 0;
            for (int x = 0; x < numbers.Length - 1; x++)
            {
                total *= numbers[x];
            }
            return total;
        }

        public static int Divide(params int[] numbers)
        {
            int total = 0;
            for(int x = 0; x < numbers.Length - 1; x++)
            {
                total /= numbers[x];
            }
            return total;
        }
    }
}
