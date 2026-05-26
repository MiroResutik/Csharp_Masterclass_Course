using System.Text.RegularExpressions;

namespace Extract_Email_with_Regex_Exercise_Section_12
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = "Contact us at support@example.com or sales@example.org.";
            // Regular expression for matching email addresses
            string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

            // Find all matches
            MatchCollection matches = Regex.Matches(input, pattern);

            // Print each matched email address
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    
    }
}
