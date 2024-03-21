using System;
using System.Threading;

namespace DelegateandEvent
{
    internal class DIYEvent
    {

    }
    //事件
    public class OrderEventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    //事件处理器
    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    //事件拥有者
    public class Customer
    {
        //手动声明的委托字段
        private OrderEventHandler orderEventHandler;

        //自定义事件
        public event OrderEventHandler MyOrder
        {
            //需要添加add和remove访问器类似于属性的get和set
            add 
            {
                if (1>0)
                {
                    Console.WriteLine("满足条件，能够订阅事件");
                    this.orderEventHandler += value;
                }
                else
                {
                    Console.WriteLine("不满足条件，无法订阅事件");
                }
                
            }
            remove 
            { 
                if(1>0)
                {
                    Console.WriteLine("满足条件");
                    this.orderEventHandler -= value;
                }
                else
                {
                    Console.WriteLine("不满足条件，无法退订事件");
                }
            }
        }

        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine("I wil pay ${0}", this.Bill);
        }

        public void WalkIn()
        {
            Console.WriteLine("Walk into the restaurant");
        }

        public void SitDown()
        {
            Console.WriteLine("Sit down");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Thinking........");
                Thread.Sleep(1000);
            }
        }

        //事件
        public void Ordered()
        {
            OrderEventArgs e = new OrderEventArgs();

            e.DishName = "辣椒炒肉";
            e.Size = "large";
            //利用事件处理器进行信息传输，当有人订阅就执行响应操作
            orderEventHandler?.Invoke(this, e);
        }

        //Customer实例可以调用的方法
        public void Action()
        {
            Console.ReadKey();
            this.WalkIn();
            this.SitDown();
            this.Think();
            this.Ordered();
        }

    }

    //事件响应者
    class Watier
    {
        //事件响应具体操作
        public void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I wile serve you the dish {0}", e.DishName);

            double price = 10;

            switch (e.Size)
            {
                case "small":
                    price *= 0.5;
                    break;
                case "large":
                    price *= 1.5;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }
    }
}
