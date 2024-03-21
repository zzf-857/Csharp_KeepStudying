using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    interface IGentleman
    {
        void Gentle();
        void Kill();
    }
    interface IKiller
    {
        void Kill();
    }

    internal class WarmKiller : IKiller, IGentleman
    {
        //接口的隐式调用
        public void Gentle()
        {
            Console.WriteLine("这是一个绅士。。");
        }

        public void Kill()
        {
            Console.WriteLine("绅士是Killer。。。");
        }

        //接口的显示调用，可以有效避免同名
        void IKiller.Kill()
        {
            Console.WriteLine("Killer原形毕露。。。。");
        }
    }
}
