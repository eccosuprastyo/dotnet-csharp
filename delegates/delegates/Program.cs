using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread summary = new Thread(o => { example.ThreadCalculate(); }); summary.Start();
        }
    }
}
