using System;
using System.Text;

namespace BerlinClock.Classes
{
    public static class BerlinClock
    {
        public static string Convert(string time)
        {
            string[] pieces = time.Split(':');
            int seconds = int.Parse(pieces[2]);
            int minutes = int.Parse(pieces[1]);
            int hours = int.Parse(pieces[0]);
            return Format(GetSeconds(seconds), GetFirstHours(hours), GetSecondHours(hours), GetFirstMinutes(minutes), GetSecondMinutes(minutes));
        }

        private static string Format(string seconds, string firstHour, string secondHour, string firstMinute, string secondMinute)
        {
            return seconds + Environment.NewLine +
                   firstHour + Environment.NewLine +
                   secondHour + Environment.NewLine +
                   firstMinute + Environment.NewLine +
                   secondMinute;
        }

        private static string GetSeconds(int second)
        {
            var sb = new StringBuilder();
            sb.Append(second % 2 == 0 ? "Y" : "O");
            return sb.ToString();
        }

        private static string GetFirstHours(int hour)
        {
            var sb = new StringBuilder();
            var lampNumber = hour / 5;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= lampNumber)
                    sb.Append("R");
                else
                    sb.Append("O");
            }

            return sb.ToString();
        }

        private static string GetSecondHours(int hour)
        {
            var sb = new StringBuilder();
            var lampNumber = hour % 5;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= lampNumber)
                    sb.Append("R");
                else
                    sb.Append("O");
            }

            return sb.ToString();
        }

        private static string GetFirstMinutes(int minutes)
        {
            var sb = new StringBuilder();
            var lampNumber = minutes / 5;
            for (int i = 1; i <= 11; i++)
            {
                if (i <= lampNumber)
                    sb.Append(i % 3 == 0 ? "R" : "Y");
                else
                    sb.Append("O");
            }

            return sb.ToString();
        }

        private static string GetSecondMinutes(int minute)
        {
            var sb = new StringBuilder();
            var lampNumber = minute % 5;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= lampNumber)
                    sb.Append("Y");
                else
                    sb.Append("O");
            }

            return sb.ToString();
        }
    }
}
