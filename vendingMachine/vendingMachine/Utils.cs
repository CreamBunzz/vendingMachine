using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vendingMachine
{
    class Utils
    {
        public static string ReadAndWrite(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
