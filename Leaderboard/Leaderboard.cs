using TypingSpeedTester.Models;

namespace TypingSpeedTester.Leaderboard
{
    public class Leaderboard
    {
        private static readonly string FilePath = "../../../Leaderboard/leaderboard.txt";

        public static List<LeaderboardEntry> LoadLeaderboard()
        {
            if (!File.Exists(FilePath))
                return new List<LeaderboardEntry>();

            return File.ReadAllLines(FilePath)
                        .Select(line => 
                        {
                            var parts = line.Split(',');
                            return new LeaderboardEntry(parts[0], double.Parse(parts[1]), double.Parse(parts[2]));
                        })
                        .ToList();
        }

        public static void SaveLeaderboard(List<LeaderboardEntry> entries)
        {
            var lines = entries.Select(entry => $"{entry.Name},{entry.WPM},{entry.Accuracy}");
            File.WriteAllLines(FilePath, lines);
        }

        public static void AddEntry(string name, double wpm, double accuracy)
        {
            var entries = LoadLeaderboard();
            entries.Add(new LeaderboardEntry(name, wpm, accuracy));

            var sortedEntries = entries.OrderByDescending(e => e.WPM).ToList();

            SaveLeaderboard(sortedEntries);
        }

        public static void DisplayTopTypists(int top = 5)
        {
            var entries = LoadLeaderboard();
            Console.WriteLine();
            Console.WriteLine("Leaderboard (Top 5)");
            Console.WriteLine("-------------------");

            foreach (var entry in entries.Take(top))
            {
                Console.WriteLine($"{entry.Name} - {entry.WPM:F2} wpm - {entry.Accuracy:F2}% Accuracy");
            }
        }
    }
}