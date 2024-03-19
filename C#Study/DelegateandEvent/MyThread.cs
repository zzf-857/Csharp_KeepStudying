using System;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateandEvent
{
    internal class MyThread
    {

    }

    class Student
    {
        public int ID { get; set; }
        public ConsoleColor Color { get; set; }

        public void DoHomework()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = this.Color;
                Console.WriteLine("{0}号学生，写作业用了{1}小时",this.ID,i);
                Thread.Sleep(1000);
            }
        }
    }
}
