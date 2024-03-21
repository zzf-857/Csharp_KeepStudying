using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace DelegateandEvent
{

    delegate void Help();

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Delegate
            Delegate();
            #endregion

            #region lambda表达式
            var d_s = "告诉你匿名函数lambda表达式";//直接根据需要修改代码
            GoStation(() => Console.WriteLine(d_s));//使用匿名函数和lambda表达式使得代码更加简洁
            #endregion

            #region 泛型委托lambda表达式混合使用
            DelegateMixed<int>((int a, int b) => { return a * b; },100,200);
            #endregion



            #region Thread
            //ThreadMethod();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.WriteLine("主程序{0}", i);
            //    Thread.Sleep(1000);
            //}
            #endregion

            #region 图形窗口Event，简易理解
            //FormEvent();
            #endregion

            #region 自定义事件
            //MyEvent();
            #endregion

            #region 在使用事件时可能出现的错误
            // ErrorEvent();
            #endregion



        }

        /// <summary>
        /// 简单委托使用
        /// </summary>
        static void Delegate()
        {

            //基础使用
            //BasicUse basicUse = new BasicUse();
            //basicUse.Run();



            //模板方法
            //ProductFactory productFactory = new ProductFactory();
            //WrapFactory wrapFactory = new WrapFactory();

            //Func<Productclass> func1 = new Func<Productclass>(productFactory.MakePizza);
            //Func<Productclass> func2 = new Func<Productclass>(productFactory.MakeToyCar);

            //Box box1 = wrapFactory.WrapProduct(func1);
            //Box box2 = wrapFactory.WrapProduct(func2);

            //Console.WriteLine(box1.Product.Name + "," + box1.Product.Description);
            //Console.WriteLine(box2.Product.Name + "," + box1.Product.Description);


            /*            Cook cook = new Cook();
                        WrapFood wrapFood = new WrapFood();

                        Func<FoodClass> GBJD = new Func<FoodClass>(cook.GBJD);
                        Func<FoodClass> LJCR = new Func<FoodClass>(cook.LJCR);

                        FoodBox foodBox1 = wrapFood.foodBox(GBJD);
                        FoodBox foodBox2 = wrapFood.foodBox(LJCR);

                        Console.WriteLine(foodBox1.MadeFood.Name);
                        Console.WriteLine(foodBox2.MadeFood.Name);*/


            //多播委托
            //MulticastDelegation multicastdelegation = new MulticastDelegation();
            //multicastdelegation.ManyDelegate();

        }

        /// <summary>
        /// lambda表达式和委托的结合使用
        /// </summary>
        /// <param name="do_sth">外部传入的一个匿名函数</param>
        static void GoStation(Help do_sth)//相当于输出变量
        {
            Console.WriteLine("来到车站");
            Console.WriteLine("看见朋友");
            do_sth();//适用于那些模糊的情况，知道需要一个行为 但是不能确定具体的行为
            Console.WriteLine("离开");
        }

        /// <summary>
        /// 泛型委托lambda表达式混合
        /// </summary>
        static void DelegateMixed<T>(Func<T, T, T> func, T x, T y)
        {
            Console.WriteLine(func(x, y));
        }


        /// <summary>
        /// 委托，线程使用
        /// </summary>
        static void ThreadMethod()
        {
            //创建对应实例
            Student student1 = new Student() { ID = 1, Color = ConsoleColor.Red };
            Student student2 = new Student() { ID = 2, Color = ConsoleColor.Yellow };
            Student student3 = new Student() { ID = 3, Color = ConsoleColor.Green };

            //创建对应的委托
            Action action1 = new Action(student1.DoHomework);
            Action action2 = new Action(student2.DoHomework);
            Action action3 = new Action(student3.DoHomework);

            //间接同步调用 委托
            //action1.Invoke();
            //action2.Invoke();
            //action3.Invoke();
            //action1 += action2;
            //action1+= action3;

            /*
            //隐式 间接异步调用，线程抢占式
            action1.BeginInvoke(null,null);
            action2.BeginInvoke(null, null);
            action3.BeginInvoke(null, null);
            
            //显示 间接异步调用，线程抢占式
            Thread thread1 = new Thread(student1.DoHomework);
            Thread thread2 = new Thread(student2.DoHomework);
            Thread thread3 = new Thread(student3.DoHomework);

            thread1.Start();
            thread2.Start();
            thread3.Start();*/

            //Task显式异步调用
            Task task1 = new Task(student1.DoHomework);
            Task task2 = new Task(student1.DoHomework);
            Task task3 = new Task(student1.DoHomework);

            task1.Start();
            task2.Start();
            task3.Start();
        }

        /// <summary>
        /// 简易事件理解
        /// </summary>
        static void FormEvent()
        {
            Form form = new Form();
            Controller controller = new Controller(form);

            form.ShowDialog();
        }

        /// <summary>
        /// 自定义事件
        /// </summary>
        static void MyEvent()
        {
            Customer customer = new Customer();
            Watier waiter = new Watier();

            customer.MyOrder += waiter.Action;

            customer.Action();
            customer.PayTheBill();
        }

        static void ErrorEvent()
        {
            Programmer programmer = new Programmer();
            Computer computer = new Computer();
            programmer.programming += computer.Action;
            //programmer.Login();


            ProgrammingEventArgs e1 = new ProgrammingEventArgs();
            e1.Password = "555";
            e1.DataBaseManager = "Hacker";


            Programmer Hacker = new Programmer();
            Hacker.programming += computer.Action;
            //处于委托字段情况下，可以直接调用订阅的方法，这样就相当于“绕过”了事件触发的条件
            //直接触发事件后运行处理逻辑
            //Hacker.programming.Invoke(programmer,e1);
            Hacker.Login();
        }
    }
}
