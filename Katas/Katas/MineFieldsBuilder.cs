using System;
using System.Linq;

namespace Katas
{
    public class MineFieldsBuilder
    {
        private const char MineChar = '*';
        private const string Dot = ".";
        private const string Zero = "0";

        public string Build(string input)
        {
            if (string.IsNullOrEmpty(input) || IsThereOnlyMine(input))
                return input;

            return input.Contains(Environment.NewLine)
                ? BuildMultiLines(input)
                : BuildOneLine(input);
        }

        private static string BuildMultiLines(string input)
        {
            var multiLines = GetMultiLines(input);
            multiLines = BuildMultiLines(multiLines);
            return string.Join(Environment.NewLine, multiLines);
        }

        private static string[] BuildMultiLines(string[] multiLines)
        {
            multiLines = multiLines.Select(BuildOneLine).ToArray();
            for (var i = 0; i < multiLines.Length; i++)
                BuildLine(multiLines, i);
            return multiLines;
        }

        private static void BuildLine(string[] multiLines, int currentIndex)
        {
            var prevLineIndex = currentIndex - 1;
            if (prevLineIndex >= 0 && multiLines[prevLineIndex].Contains(MineChar))
                multiLines[currentIndex] = BuildLine(multiLines[currentIndex].ToCharArray(), multiLines[prevLineIndex].ToCharArray());

            var nextLineIndex = currentIndex + 1;
            if (nextLineIndex < multiLines.Length && multiLines[nextLineIndex].Contains(MineChar))
                multiLines[currentIndex] = BuildLine(multiLines[currentIndex].ToCharArray(), multiLines[nextLineIndex].ToCharArray());
        }

        private static string BuildLine(char[] currentLine, char[] relativeLine)
        {
            for (var charIndex = 0; charIndex < relativeLine.Length; charIndex++)
                if (relativeLine[charIndex] == MineChar)
                    BuildChar(charIndex, currentLine);
            return string.Concat(currentLine);
        }

        private static string[] GetMultiLines(string input)
        {
            return input.Replace(Environment.NewLine, "|").Split('|');
        }

        private static bool IsThereOnlyMine(string input)
        {
            return !input.Contains(Dot);
        }

        private static string BuildOneLine(string input)
        {
            var line = input.Replace(Dot, Zero);
            if (!IsThereMine(line))
                return line;

            var allChars = line.ToCharArray();
            return BuildLine(allChars, allChars);
        }

        private static void BuildChar(int mineIndex, char[] allPositions)
        {
            if (allPositions[mineIndex] != MineChar)
                allPositions[mineIndex] = BuildNoMineChar(allPositions, mineIndex);

            var prevIndex = mineIndex - 1;
            if (prevIndex >= 0 && allPositions[prevIndex] != MineChar)
                allPositions[prevIndex] = BuildNoMineChar(allPositions, prevIndex);

            var nextIndex = mineIndex + 1;
            if (nextIndex < allPositions.Length && allPositions[nextIndex] != MineChar)
                allPositions[nextIndex] = BuildNoMineChar(allPositions, nextIndex);
        }

        private static char BuildNoMineChar(char[] chars, int charIndex)
        {
            var stringValue = chars[charIndex].ToString();
            var parsedChar = int.Parse(stringValue);
            var number = parsedChar + 1;
            var @char = char.Parse(number.ToString());
            return @char;
        }

        private static bool IsThereMine(string input)
        {
            return input.Contains(MineChar);
        }
    }
}
