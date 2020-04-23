using System;

namespace BerlinClock.Classes
{

    public class SecondBlinkProvider
    {
        private const int factor = 2;

        public string GetLamps(int time)
        {
            if (time < 0 || time > 60)
                throw new ArgumentOutOfRangeException(nameof(time), "Provided valued is out of the expected range [0-60]");

            return time % factor == 0 ? $"{Constants.Lamps.YELLOW}" : $"{Constants.Lamps.OFF}";
        }
    }
}
