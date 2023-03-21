using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeLongCompare
{
    class Program
    {
        static void Main(string[] args)
        {

            double MyFisrtDate = DateTime.Now.ToOADate();

            Console.WriteLine("Show DateTime As Double : {0}", MyFisrtDate);
            Console.WriteLine("Show Double As DateTime : {0}", DateTime.FromOADate(MyFisrtDate));
            Console.WriteLine("Wait some Sec and press Enter for a Diff Example");
            Console.ReadLine();
            double MyEndDate = DateTime.Now.ToOADate();
            // not working with TimeSpan
            double diff = MyEndDate - MyFisrtDate;
            Console.WriteLine("Show Diff Double As DateTime : {0}", DateTime.FromOADate(diff));

            Console.ReadLine();
            
            Console.WriteLine("now with long");

            long myStart = DateTime.Now.Ticks;
            Console.WriteLine("Show DateTime As Long : {0}", myStart);
            Console.WriteLine("Show long As DateTime : {0}", new DateTime(myStart));

            Console.WriteLine("Wait some Sec and press Enter for a Diff Example");
            Console.ReadLine();
            long myEnd = DateTime.Now.Ticks;

            long mydiff = myEnd - myStart;
            Console.WriteLine("Show long As TimeSpan : {0}", new TimeSpan(mydiff));
            Console.ReadLine();
        }
    }
}