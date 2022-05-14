using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading
{
    class MatrixClass
    {
        Random rand;
        readonly object locker = new object();
        const string litters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //--------------------------------------------------------------

        public int Column { get; set; }

        public bool NeedSecond { get; set; }
        //--------------------------------

        public MatrixClass(int column, bool needSecond)
        {
            Column = column;
            rand = new Random((int)DateTime.Now.Ticks);
            NeedSecond = needSecond;
        }
        //--------------------------------

        public char GetStr()
        {
            return litters.ToCharArray()[rand.Next(0, 35)];
        }
        //---------------------------

        public void Move()
        {
            int count;
            int length;
            while (true)
            {
                count = rand.Next(3, 12);
                length = 0;
                Thread.Sleep(rand.Next(50, 5000));

                for(int i = 0; i < 40; i++)
                {
                    lock(locker)
                    {
                        Console.CursorTop = 0;
                        Console.ForegroundColor = ConsoleColor.Black;

                        for(int j = 0; j < i; j++)
                        {
                            Console.CursorLeft = Column;
                            Console.WriteLine("█");
                        }

                        if (length < count)
                            length++;
                        else if
                            (length == count)
                            count = 0;
                        if(NeedSecond && i < 20 && i < length +2 && rand.Next(1, 5) == 3)
                        {
                            new Thread((new MatrixClass(Column, false)).Move).Start();
                            NeedSecond = false;
                        }

                        if(39 - i < length)
                            --length;
                       
                        Console.CursorTop = i - length + 1;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        for(int j = 0; j < length -2; j++)
                        {
                            Console.CursorLeft = Column;
                            Console.WriteLine(GetStr());
                        }
                        if(length >= 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.CursorLeft = Column;
                            Console.WriteLine(GetStr());
                        }
                        if(length >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.CursorLeft = Column;
                            Console.WriteLine(GetStr());
                        }
                        Thread.Sleep(20);
                    }
                }
            }
        }
        //---------------------------

    }
}
