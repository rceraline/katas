using System;
using System.Collections.Generic;
using System.Linq;

namespace LcdKata
{
    public class Lcd
    {
        public string Generate(string input)
        {
            var allLines = input.ToCharArray().Select(GetChar).ToList();

            var line1 = FormatOneLine(allLines, 0);
            var line2 = FormatOneLine(allLines, 1);
            var line3 = FormatOneLine(allLines, 2);
            return FormatMultiLines(line1, line2, line3);
        }

        private static string FormatOneLine(IEnumerable<string[]> allLines, int lineNumber)
        {
            return string.Join(" ", allLines.Select(line => line[lineNumber]));
        }

        private static string[] GetChar(char number)
        {
            switch (number)
            {
                case '0':
                    return new[] {"._.", "|.|", "|_|"};
                case '1':
                    return new[] {"...", "..|", "..|"};
                case '2':
                    return new[] {"._.", "._|", "|_."};
                case '3':
                    return new[] {"._.", "._|", "._|"};
                case '4':
                    return new[] {"...", "|_|", "..|"};
                case '5':
                    return new[] {"._.", "|_.", "._|"};
                case '6':
                    return new[] {"._.", "|_.", "|_|"};
                case '7':
                    return new[] {"._.", "..|", "..|"};
                case '8':
                    return new[] {"._.", "|_|", "|_|"};
                case '9':
                    return new[] {"._.", "|_|", "..|"};
            }

            throw new NotSupportedException("Invalid string.");
        }

        private static string FormatMultiLines(string line1, string line2, string line3)
        {
            return string.Concat(line1, Environment.NewLine, line2, Environment.NewLine, line3);
        }
    }
}
