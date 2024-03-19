using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace DelegateandEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Delegate
            //Delegate();
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
            MyEvent();
            #endregion




        }

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

            Cook cook = new Cook();
            WrapFood wrapFood = new WrapFood();

            Func<FoodClass> GBJD = new Func<FoodClass>(cook.GBJD);
            Func<FoodClass> LJCR = new Func<FoodClass>(cook.LJCR);

            FoodBox foodBox1 = wrapFood.foodBox(GBJD);
            FoodBox foodBox2 = wrapFood.foodBox(LJCR);

            Console.WriteLine(foodBox1.MadeFood.Name);
            Console.WriteLine(foodBox2.MadeFood.Name);
        }


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

        static void FormEvent()
        {
            Form form = new Form();
            Controller controller = new Controller(form);

            form.ShowDialog();
        }


        static void MyEvent()
        {
            Customer customer = new Customer();
            Watier waiter = new Watier();
            customer.MyOrder += waiter.Action;

            customer.Action();
            customer.PayTheBill();
        }
    }
}
