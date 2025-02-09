using System.Text.RegularExpressions;

namespace Sequence
{
    public static class Checker
    {
        public static List<int> CheckSequence(string input)
        {
            // Regex to check if the input string only contains numbers and white space
            if (!Regex.IsMatch(input, @"^[\d\s]+$"))
            {
                throw new ArgumentException("Input string contains invalid characters. Only numbers and white space are allowed.");
            }

            var values = input.Split(' ').Select(int.Parse).ToList();
            int maxLength = 0;
            int currentLength = 0;
            int startIndex = 0;
            int bestStartIndex = 0;

            for (int i = 0; i < values.Count; i++)
            {
                if (i == 0 || values[i] > values[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        bestStartIndex = startIndex;
                    }
                    startIndex = i;
                    currentLength = 1;
                }
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                bestStartIndex = startIndex;
            }

            return values.Skip(bestStartIndex).Take(maxLength).ToList();
        }
    }
}
