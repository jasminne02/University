using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public delegate void PrintMessage(string message);

    class CountdownClock
    {
        private string message;
        private int seconds;

        public string Message { get { return message; } }
        public int Seconds { get { return seconds; } }

        PrintMessage echoTheMessage = Observer.EchoTheMessage;

        public event EventHandler OnPrintMessage;
        
        public CountdownClock(string message, int seconds)
        {
            this.message = message;
            this.seconds = seconds;

            Thread.Sleep(seconds * 1000);
            echoTheMessage(message);
        }

    }
}
