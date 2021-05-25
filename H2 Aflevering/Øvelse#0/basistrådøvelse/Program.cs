
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class threprog
{
    public static void Main()
    {
        program pg = new program();
        for (int i = 0; i < 2; i++)
        {
            Thread thread = new Thread(new ThreadStart(pg.WorkThreadFunction));
            thread.Name = "Thread(" + i + ")";
            thread.Start();

        }
        Console.Read();
    }
}
class program
{
    public void WorkThreadFunction()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(Thread.CurrentThread.Name + ": Simple Thread");
        }
    }
}