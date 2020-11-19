using System;

namespace BerlinClock.Classes
{
    public class OneHourLineProvider
    {
        private const int _factor = 5;

        public string GetLamps(int time)
        {
            if (time < 0 || time > 24)
                throw new ArgumentOutOfRangeException(nameof(time), "Provided valued is out of the expected range [0-24]");

            var lamps = new char[4];
            int lampNumber = time % _factor;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= lampNumber)
                    lamps[i - 1] = Constants.Lamps.RED;
                else
                    lamps[i - 1] = Constants.Lamps.OFF;
            }
            return new string(lamps);
        }
    }
}
