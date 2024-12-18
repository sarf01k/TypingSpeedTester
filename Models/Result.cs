namespace TypingSpeedTester.Models
{
    public class Result
    {
        public double TimeTaken { get; set; }
        public double Accuracy { get; set; }
        public double WPM { get; set; }

        public void DisplayResult(double timeTaken, double accuracy, double wpm)
        {
            Console.WriteLine();
            Console.WriteLine($"Time taken: {timeTaken:F2} seconds");
            Console.WriteLine($"Accuracy: {accuracy:F2}%");
            Console.WriteLine($"Typing speed: {wpm:F2} WPM");
            Console.WriteLine();
        }
    }
}