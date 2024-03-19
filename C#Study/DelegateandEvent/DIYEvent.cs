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
        //事件处理器实例化
        private OrderEventHandler orderEventHandler;

        //自定义事件
        public event OrderEventHandler MyOrder
        {
            add { this.orderEventHandler += value; }
            remove { this.orderEventHandler -= value; }
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
            orderEventHandler?.Invoke(this, e);
        }

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
