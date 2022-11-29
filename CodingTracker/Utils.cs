using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class Utils
    {
        internal static int GetDuration(DateTime dateTime1, DateTime dateTime2)
        {
            return 0;
        }
        internal static ConsoleKey MenuKeyEnum(int key) => key switch
        {
            1 => ConsoleKey.D1,
            2 => ConsoleKey.D2,
            3 => ConsoleKey.D3,
            4 => ConsoleKey.D4,
            5 => ConsoleKey.D5,
            6 => ConsoleKey.D6,
            7 => ConsoleKey.D7,
            8 => ConsoleKey.D8,
            9 => ConsoleKey.D9,
            _ => ConsoleKey.NoName,
        };
    }
}
