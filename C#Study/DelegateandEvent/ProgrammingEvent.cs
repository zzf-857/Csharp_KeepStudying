using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateandEvent
{
    public class ProgrammingEvent
    {

    }

    //事件
    public class ProgrammingEventArgs
    {
        public string DataBaseManager { get; set; }
        public string Password { get; set; }
    }

    //委托
    public delegate void ProgrammingEventHandler(Programmer programmer, ProgrammingEventArgs e);


    //事件拥有者
    public class Programmer
    {
        //事件处理器
        public ProgrammingEventHandler programming;
        //自定义事件
        public event ProgrammingEventHandler PROGRAMMING
        {
            add { programming += value; }
            remove { programming -= value; }
        }

        //这些不同的方法代表的就是不同的事件拥有者（发出者）不同的处理逻辑，
        //可以有不同的行为然后通过不同的行为触发得到不同的事件响应
        protected void Register()
        {

            ProgrammingEventArgs e = new ProgrammingEventArgs();
            e.DataBaseManager = "数据库管理员";
            e.Password = "123";

            programming?.Invoke(this, e);
        }

        protected void Hacking()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Hacking......");
                Thread.Sleep(1000);
            }
            Console.WriteLine("成功进入！");

            ProgrammingEventArgs e1 = new ProgrammingEventArgs();
            e1.Password = "555";
            e1.DataBaseManager = "Hacker";
            programming?.Invoke(this, e1);
        }

        protected void Entering()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Entering......");
                Thread.Sleep(1000);
            }
        }

        //这个方法是一套事件处理流程，通过在这一个类中来决定调用哪些方法，
        //最后再使用public暴露给外界，这样就能保证外界的一些实例无法直接单独调用方法，
        //提高了程序安全性。
        //这种适用于一些需要多个方法执行的操作，执行一系列的逻辑后再触发事件
        public void Login()
        {
            //Entering();
            //Register();
            Hacking();
        }
    }

    //事件响应者,必须有事件订阅才会调用，事件触发条件处需要有非空判断（需要有订阅者才会响应）
    public class Computer
    {
        public void Action(Programmer programmer, ProgrammingEventArgs e)
        {
            Console.WriteLine("Welcome to the DataBase! {0}", e.DataBaseManager);

            Console.WriteLine(e.Password == "123" ? "正常登陆！欢迎光临" : "找到程序漏洞！黑入程序");
        }
    }
}
