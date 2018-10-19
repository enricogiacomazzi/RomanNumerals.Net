using System;
using System.Collections.Generic;
using System.Linq;


namespace RomanNumerals
{
    public static class RomanNumerals
    {
        private static readonly Dictionary<char, int> Symbols = new Dictionary<char, int>();
        private static readonly Dictionary<string, int> ExtendedSymbols = new Dictionary<string, int>();
        private static readonly char[] allowedChars;

        static RomanNumerals()
        {
            Symbols.Add('M', 1000);
            Symbols.Add('D', 500);
            Symbols.Add('C', 100);
            Symbols.Add('L', 50);
            Symbols.Add('X', 10);
            Symbols.Add('V', 5);
            Symbols.Add('I', 1);

            allowedChars = Symbols.Keys.ToArray();

            ExtendedSymbols.Add("M", 1000);
            ExtendedSymbols.Add("CM", 900);
            ExtendedSymbols.Add("D", 500);
            ExtendedSymbols.Add("CD", 400);
            ExtendedSymbols.Add("C", 100);
            ExtendedSymbols.Add("XC", 90);
            ExtendedSymbols.Add("L", 50);
            ExtendedSymbols.Add("XL", 40);
            ExtendedSymbols.Add("X", 10);
            ExtendedSymbols.Add("IX", 9);
            ExtendedSymbols.Add("V", 5);
            ExtendedSymbols.Add("IV", 4);
            ExtendedSymbols.Add("I", 1);
        }

        public static string Convert(int value)
        {
            if(value < 0)
                throw new Exception("value nust be positive");

            var result = String.Empty;

            if (value == 0)
                return result;

            foreach (var s in ExtendedSymbols)
            {
                var item = value / s.Value;
                value %= s.Value;

                for (int i = 0; i < item; i++)
                {
                    result += s.Key;
                }
            }

            return result;
        }

        public static int Convert(string value)
        {
            var parsedValue = value.ToUpper().Trim();
            if(parsedValue.ToCharArray().Except(allowedChars).Any())
                throw new Exception("invalid chars in value");

            var items = parsedValue.Select(x => Symbols[x]).ToArray();
            var len = items.Length;
            var result = 0;

            for (int i = 0; i < len; i++)
            {
                var item = items[i];
                result += i + 1 < len && item < items[i + 1] ? -item : item;
            }

            return result;
        }
    }
}