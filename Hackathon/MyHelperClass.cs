using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHelperClassRepo
{
    class MyHelperClass
    {
        internal static int GetNumber(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        internal static string GetValue(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
