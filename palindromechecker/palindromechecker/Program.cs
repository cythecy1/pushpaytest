using System;
using System.Linq;

namespace palindromechecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SUNSHINE".IsPalindrome());
            Console.WriteLine("NURSESRUN".IsPalindrome());
            Console.WriteLine("IAMMAI".IsPalindrome());
            Console.WriteLine("tattarRattaT".IsPalindrome());
        }
    }

    public static class PalindromeChecker
    {
        public static bool IsPalindrome(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;

            if(input.Length < 2)
                return false;

            if (!input.Substring(0, 1).Equals(input.Substring(input.Length - 1, 1), StringComparison.CurrentCultureIgnoreCase)) //Quick return if first letter and last letter are not same
                return false;

            if (input.Length % 2 == 0)
            {
                return IsPalindromEven(input);
            }
            else
            {
                return IsPalindromeOdd(input);
            }
        }

        private static bool IsPalindromeOdd(string input)
        {
            string firsthalf = input.Substring(0, (input.Length - 1) / 2);
            int secondhalfIndexStart = ((input.Length - 1) / 2) + 1;
            string secondhalf = input.Substring(secondhalfIndexStart, input.Length - secondhalfIndexStart);

            return PalindromeChecker.IsPalindromEven($"{firsthalf}{secondhalf}");
        }

        private static bool IsPalindromEven(string input)
        {
            string firsthalf = input.Substring(0, input.Length / 2);
            string secondhalf = input.Substring((input.Length / 2), input.Length / 2);

            secondhalf = new String(secondhalf.ToCharArray().Reverse().ToArray());
            return firsthalf.Equals(secondhalf, StringComparison.CurrentCultureIgnoreCase);

        }
    }
}
