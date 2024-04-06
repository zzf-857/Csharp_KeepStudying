using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ThreadLeaning
{
    internal class Program
    {

        //加锁必须要引用类型
        static object obj=new object();
        static void Main(string[] args)
        {
            //创建线程
            Thread t = new Thread(NewThreadLogic);

            //启动线程
            t.Start();

            //设置为后台线程：当主线程结束后该线程跟着结束
            t.IsBackground = true;

            //关闭
            //使用while循环，传入一个bool类型的参数进行控制



            //线程加锁lock
            for (int i = 0; i < 10; i++)
            {
                //不加锁
                //Thread.Sleep(200);
                //Console.ForegroundColor = ConsoleColor.Green;
                //consol("主线程");

                //加锁方式一：
                //lock (obj)
                //{
                //    Thread.Sleep(200);
                //    Console.ForegroundColor = ConsoleColor.Green;
                //    consol("主线程");
                //}

                //加锁方式二：
                Monitor.Enter(obj);
                try
                {
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Green;
                    consol("主线程");
                }
                catch (Exception)
                {

                    throw;
                }
                finally 
                { 
                    Monitor.Exit(obj); 
                }
            }
            
        }

        static void NewThreadLogic()
        {
            for (int i = 0; i < 10; i++)
            {
                //不加锁
                //Thread.Sleep(200);
                //Console.ForegroundColor = ConsoleColor.Red;
                //consol("新线程");

                //方法一：
                //lock(obj) 
                //{
                //    Thread.Sleep(200);
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    consol("新线程");
                //}

                //方法二：
                Monitor.Enter(obj);
                try
                {
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Red;
                    consol("新线程");
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    Monitor.Exit(obj);
                }
            }
        }

        static void consol(string s)
        {
            Console.WriteLine(s);



            //房租1550
            //水电100-200（算一百五）
            //吃饭：20*60=1200
            //通勤：10*30=300
            //工资：5000
            //总共：5000-1550-150-1200-300=1800
        }
    }
}
