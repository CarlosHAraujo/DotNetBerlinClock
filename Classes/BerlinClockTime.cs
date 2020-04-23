using System;
using System.Linq;

namespace BerlinClock.Classes
{
    public class BerlinClockTime
    {
        private readonly ILineProvider secondBlinkProvider;
        private readonly ILineProvider fiveHoursProvider;
        private readonly ILineProvider oneHourProvider;
        private readonly ILineProvider fiveMinutesProvider;
        private readonly ILineProvider oneMinuteProvider;

        public BerlinClockTime(SecondBlinkProvider secondBlink, FiveHoursLineProvider fiveHours, OneHourLineProvider oneHour, FiveMinutesLineProvider fiveMinutes, OneMinuteLineProvider oneMinute)
        {
            secondBlinkProvider = secondBlink;
            fiveHoursProvider = fiveHours;
            oneHourProvider = oneHour;
            fiveMinutesProvider = fiveMinutes;
            oneMinuteProvider = oneMinute;
        }

        public string FiveHours { get; private set; }

        public string OneHour { get; private set; }

        public string FiveMinutes { get; private set; }

        public string OneMinute { get; private set; }

        public string Seconds { get; private set; }

        public BerlinClockTime Parse(string value)
        {
            value = value ?? throw new ArgumentNullException(nameof(value), "Please provide a value for the BerlinClock time.");
            string[] pieces = value.Split(':');
            if (pieces.Length < 3)
                throw new ArgumentException($"Unable to parse value {value} as Berlin Clock", nameof(value));

            if (!int.TryParse(pieces[0], out int hours))
                throw new ArgumentOutOfRangeException(nameof(hours), $"Unable to extract hours out of the time {pieces[0]}");
            if (!int.TryParse(pieces[1], out int minutes))
                throw new ArgumentOutOfRangeException(nameof(minutes), $"Unable to extract minutes out of the time {pieces[1]}");
            if (!int.TryParse(pieces[2], out int seconds))
                throw new ArgumentOutOfRangeException(nameof(seconds), $"Unable to extract seconds out of the time {pieces[2]}");

            FiveHours = new string(fiveHoursProvider.GetLamps(hours).ToArray());
            OneHour = new string(oneHourProvider.GetLamps(hours).ToArray());
            FiveMinutes = new string(fiveMinutesProvider.GetLamps(minutes).ToArray());
            OneMinute = new string(oneMinuteProvider.GetLamps(minutes).ToArray());
            Seconds = new string(secondBlinkProvider.GetLamps(seconds).ToArray());

            return this;
        }
    }
}
