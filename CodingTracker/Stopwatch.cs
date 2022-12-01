using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodingTracker
{
    internal class SessionStopwatch
    {
        internal static void Session()
        {
            var timer = new Stopwatch();
            Console.CursorVisible= false;
            timer.Start();
            while (timer.IsRunning)
            {
                Console.WriteLine(timer.Elapsed.ToString());
                Console.CursorTop -= 1;
                Console.CursorLeft = 0;
            }

        }
    }
}
