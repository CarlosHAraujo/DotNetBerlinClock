using System;

namespace BerlinClock.Classes
{
    public class BerlinClockTime
    {
        private readonly SecondBlinkProvider _secondBlinkProvider;
        private readonly FiveHoursLineProvider _fiveHoursProvider;
        private readonly OneHourLineProvider _oneHourProvider;
        private readonly FiveMinutesLineProvider _fiveMinutesProvider;
        private readonly OneMinuteLineProvider _oneMinuteProvider;

        public BerlinClockTime(SecondBlinkProvider secondBlink, FiveHoursLineProvider fiveHours, OneHourLineProvider oneHour, FiveMinutesLineProvider fiveMinutes, OneMinuteLineProvider oneMinute)
        {
            _secondBlinkProvider = secondBlink;
            _fiveHoursProvider = fiveHours;
            _oneHourProvider = oneHour;
            _fiveMinutesProvider = fiveMinutes;
            _oneMinuteProvider = oneMinute;
        }

        private BerlinClockTime() { }

        public string FiveHours { get; private set; }

        public string OneHour { get; private set; }

        public string FiveMinutes { get; private set; }

        public string OneMinute { get; private set; }

        public char Seconds { get; private set; }

        public BerlinClockTime Parse(string value)
        {
            var pieces = value?.Split(":");
            if (pieces is null || pieces.Length < 3)
                throw new ArgumentException($"Unable to parse value {value} as Berlin Clock", nameof(value));

            try
            {
                (int hours, int minutes, int seconds) = (int.Parse(pieces[0]), int.Parse(pieces[1]), int.Parse(pieces[2]));

                return new BerlinClockTime
                {
                    FiveHours = _fiveHoursProvider.GetLamps(hours),
                    OneHour = _oneHourProvider.GetLamps(hours),
                    FiveMinutes = _fiveMinutesProvider.GetLamps(minutes),
                    OneMinute = _oneMinuteProvider.GetLamps(minutes),
                    Seconds = _secondBlinkProvider.GetLamps(seconds)
                };
            }
            catch (FormatException ex)
            {
                throw new ArgumentException($"Unable to extract hours out of the time: {value}", nameof(value), ex);
            }
        }

        public override string ToString() => $"{Seconds}{Environment.NewLine}{FiveHours}{Environment.NewLine}{OneHour}{Environment.NewLine}{FiveMinutes}{Environment.NewLine}{OneMinute}";
    }
}
