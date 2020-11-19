using System;

namespace BerlinClock.Classes
{
    public class OneMinuteLineProvider
    {
        private const int _factor = 5;

        public string GetLamps(int time)
        {
            if (time < 0 || time > 60)
                throw new ArgumentOutOfRangeException(nameof(time), "Provided valued is out of the expected range [0-60]");

            var lamps = new char[4];
            var lampNumber = time % _factor;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= lampNumber)
                    lamps[i - 1] = Constants.Lamps.YELLOW;
                else
                    lamps[i - 1] = Constants.Lamps.OFF;
            }
            return new string(lamps);
        }
    }
}
