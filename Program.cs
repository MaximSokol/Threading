using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading
{
    class Program
    {
        // Task 1

        //public static void SecondMethod()
        //{
        //    Console.WriteLine("SecondCalling");
        //    while (true)
        //    {
        //        SecondMethod();
        //    }
        //}


        static void Main(string[] args)
        {
            // Task 1.1



            //ThreadStart start = new ThreadStart(SecondMethod);
            //Thread th = new Thread(start);
            //th.Start();

            //while (true)
            //{
            //    Console.WriteLine(new string(' ', 15) + "FirstCalling");
            //}



            // Task 2.2

            MatrixClass matr;

            for(int i = 0; i < 40; i++)
            {
                matr = new MatrixClass(40, true);
                new Thread(matr.Move).Start();
            }


        }
    }
}
