namespace TypingSpeedTester.Models
{
    public class LeaderboardEntry
    {
        public string Name { get; set; }
        public double WPM { get; set; }
        public double Accuracy { get; set; }

        public LeaderboardEntry(string name, double wpm, double accuracy)
        {
            Name = name;
            WPM = wpm;
            Accuracy = accuracy;
        }
    }
}