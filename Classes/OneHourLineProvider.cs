using System;
using System.Collections.Generic;

namespace BerlinClock.Classes
{

    public class OneHourLineProvider : ILineProvider
    {
        private const int factor = 5;

        public string GetLamps(int time)
        {
            if (time < 0 || time > 24)
                throw new ArgumentOutOfRangeException(nameof(time), "Provided valued is out of the expected range [0-24]");

            var lamps = new List<char>();
            var lampNumber = time % factor;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= lampNumber)
                    lamps.Add(Constants.Lamps.RED);
                else
                    lamps.Add(Constants.Lamps.OFF);
            }
            return new string(lamps.ToArray());
        }
    }
}
