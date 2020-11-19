using System;

namespace BerlinClock.Classes
{
    public class FiveMinutesLineProvider
    {
        private const int _factor = 5;

        public string GetLamps(int time)
        {
            if (time < 0 || time > 60)
                throw new ArgumentOutOfRangeException(nameof(time), "Provided valued is out of the expected range [0-60]");

            var lamps = new char[11];
            int lampNumber = time / _factor;
            for (int i = 1; i <= 11; i++)
            {
                if (i <= lampNumber)
                    lamps[i - 1] = (i % 3 == 0 ? Constants.Lamps.RED : Constants.Lamps.YELLOW);
                else
                    lamps[i - 1] = (Constants.Lamps.OFF);
            }
            return new string(lamps);
        }
    }
}
