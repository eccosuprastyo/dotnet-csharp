using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates
{
    class example
    {
        internal delegate void ThreadSummary(int val1, int val2);

        public static void ThreadCalculate()
        {
            while (true)
            {
                Console.WriteLine("==========Summary===========");
                string val1;
                string val2;
                Console.Write("Enter first integer: ");
                val1 = Console.ReadLine();
                Console.Write("Enter second integer: ");
                val2 = Console.ReadLine();

                ThreadSummary sum = new ThreadSummary(ProcessSummary);
                sum.Invoke(Convert.ToInt32(val1), Convert.ToInt32(val2));
            }
        }

        internal static void ProcessSummary(int val1, int val2)
        {
            int result = val1 + val2;
            Console.WriteLine("Your Summary Input: {0}", result);
            Console.WriteLine("============================");
        }
    }
}
