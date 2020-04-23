﻿using System;
using System.Text;

namespace BerlinClock.Classes
{

    public class BerlinClockFormater
    {
        public string Format(string seconds, string firstHour, string secondHour, string firstMinute, string secondMinute)
        {
            return seconds + Environment.NewLine +
                   firstHour + Environment.NewLine +
                   secondHour + Environment.NewLine +
                   firstMinute + Environment.NewLine +
                   secondMinute;
        }
    }
}
