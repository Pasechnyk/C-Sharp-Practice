using System;
using System.Text.RegularExpressions;

// Task 1-4 - Work with regular expressions using different patterns 

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1 - Create pattern with 4-digits

            // pattern
            string pattern = @"^\d{4}$";

            bool isValid = false;
            do
            {
                Console.WriteLine("Enter your number: ");
                string number = Console.ReadLine();

                var regexp = new Regex(pattern);
                isValid = regexp.IsMatch(number);

                Console.WriteLine(isValid ? "It is 4-digit number" : "Not a 4-digit number!");
            } while (true);


            // Task 2 - Create pattern with repetitive 3 words and 3 numbers

            // pattern
            string pattern2 = @"^\w{3}\d{3}\w{3}\d{3}$";

            Console.WriteLine("Enter your string: ");
            string text = Console.ReadLine();

            var regexp2 = new Regex(pattern2);
            bool isValid2 = regexp2.IsMatch(pattern2);

            Console.WriteLine(isValid2 ? "The text is suitable!" : "Not suitable!");


            // Task 3 - Create a pattern with a 3-letter abbreviation

            // pattern
            string pattern3 = "^[A-Z]{3}$";

            var regexp3 = new Regex(pattern3);
            while (true)
            {
                Console.WriteLine("Enter your text: ");
                string text2 = Console.ReadLine();

                Console.WriteLine(
                    text2 != null && regexp3.IsMatch(text2)
                        ? $"\"{text2}\" has matched \"{pattern3}\""
                        : $"\"{text2}\" hasn't matched \"{pattern3}\"");
            }

            // Task 4 - Create a pattern for years between 1900 to 2099

            // pattern
            string pattern4 = @"^(19|20)\d{2}$";

            var regexp4 = new Regex(pattern4);
            while (true)
            {
                Console.WriteLine("Enter the year: ");
                string year = Console.ReadLine();

                Console.WriteLine(
                    year != null && regexp3.IsMatch(year)
                        ? $"\"{year}\" has matched \"{pattern4}\""
                        : $"\"{year}\" hasn't matched \"{pattern4}\"");
            }
        }
    }
}
