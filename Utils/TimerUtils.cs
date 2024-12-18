namespace TypingSpeedTester.Utils
{
    public class TimerUtils
    {
        public static double CalculateTimeTaken(DateTime startTime, DateTime endTime)
        {
            return (endTime - startTime).TotalSeconds;
        }

        public static double CalculateWPM(int wordCount, double timeTaken)
        {
            return wordCount/(timeTaken/60.0);
        }
    }
}