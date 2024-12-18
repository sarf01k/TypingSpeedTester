using TypingSpeedTester.Leaderboard;
using TypingSpeedTester.Models;
using TypingSpeedTester.Utils;

namespace TypingSpeedTester
{
    class Program
    {
        static void Main()
        {
            Console.Title = "TypingSpeedTester";
            Console.WriteLine("Select difficulty [1 - 3]:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard\n");

            Console.Write("> ");

            int difficulty;
            if (!int.TryParse(Console.ReadLine(), out difficulty) || difficulty > 3 || difficulty < 0)
            {
                Console.WriteLine("Please choose a difficulty [1 - 3]\nPress any key to exit...");
                Console.ReadKey();
                return;
            }

            Random random = new();
            string[] sentences = File.ReadAllLines("../../../Sentences/sentences.txt");
            string sentence = string.Empty;
            
            switch (difficulty)
            {
                case 1:
                    sentence = sentences[random.Next(1, 10 + 1)];
                    break;
                case 2:
                    sentence = sentences[random.Next(13, 22 + 1)];
                    break;
                case 3:
                    sentence = sentences[random.Next(25, 34 + 1)];
                    break;
            }

            Console.Write($"\nType this: {sentence}");
            Console.Write("\n> ");

            DateTime startTime = DateTime.Now;

            string input = "";
            int incorrectChars = 0;

            while (true)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(intercept: true);

                if (keyPressed.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (keyPressed.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        incorrectChars++;
                        input = input.Substring(0, input.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    input += keyPressed.KeyChar;
                    Console.Write(keyPressed.KeyChar);
                }
            }

            DateTime endTime = DateTime.Now;

            double timeTaken = TimerUtils.CalculateTimeTaken(startTime, endTime);
            int wordCount = sentence.Split(' ',  StringSplitOptions.RemoveEmptyEntries).Length;
            double wpm = TimerUtils.CalculateWPM(wordCount, timeTaken);
            int correctChars = 0;
            for (int i = 0; i < Math.Min(input.Length, sentence.Length); i++)
            {
                if (input[i] == sentence[i])
                    correctChars++;
            }
            double accuracy = (double)(correctChars - incorrectChars) / sentence.Length * 100;

            Result result = new();
            result.DisplayResult(timeTaken, accuracy, wpm);

            Console.Write("Enter your name for the leaderboard: ");
            string name = Console.ReadLine();

            Leaderboard.Leaderboard.AddEntry(name, wpm, accuracy);
            Leaderboard.Leaderboard.DisplayTopTypists(5);

            Console.ReadLine();
        }
    }
}