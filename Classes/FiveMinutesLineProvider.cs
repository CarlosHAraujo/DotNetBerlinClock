using System;
using System.Collections.Generic;

namespace BerlinClock.Classes
{

    public class FiveMinutesLineProvider
    {
        private const int factor = 5;
        public string GetLamps(int time)
        {
            if (time < 0 || time > 60)
                throw new ArgumentOutOfRangeException(nameof(time), "Provided valued is out of the expected range [0-60]");

            var lamps = new List<char>();
            var lampNumber = time / factor;
            for (int i = 1; i <= 11; i++)
            {
                if (i <= lampNumber)
                    lamps.Add(i % 3 == 0 ? Constants.Lamps.RED : Constants.Lamps.YELLOW);
                else
                    lamps.Add(Constants.Lamps.OFF);
            }
            return new string(lamps.ToArray());
        }
    }
}
