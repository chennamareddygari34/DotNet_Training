namespace Length
{
    class Program
        {
          static void Main(string[] args)

           {
                Console.Write("Enter a list of words separated by commas: ");
                string input = Console.ReadLine();

                // Split the input string into an array of words
                string[] words = input.Split(',');

                if (words.Length == 0)
                {
                    Console.WriteLine("No words entered.");
                    return;
                }

                string shortestWord = words[0].Trim();
                string longestWord = words[0].Trim();

                foreach (string word in words)
                {
                    string trimmedWord = word.Trim();
                    if (trimmedWord.Length < shortestWord.Length)
                    {
                        shortestWord = trimmedWord;
                    }

                    if (trimmedWord.Length > longestWord.Length)
                    {
                        longestWord = trimmedWord;
                    }
                }

                Console.WriteLine($"Shortest word: {shortestWord}");
                Console.WriteLine($"Longest word: {longestWord}");
           }
    }
}