using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Csharpimprove
{
    public abstract class MagicItem
    {
        public abstract void Use();
    }

    public class Sword : MagicItem
    {
        public override void Use()
        {
            Console.WriteLine("生成了一把剑");
        }
    }

    public class Potion : MagicItem
    {
        public override void Use()
        {
            Console.WriteLine("拿出了药剂");
        }
    }

    public class Frog
    {
        public void Ribbit()
        {
            Console.WriteLine("呱呱呱");
        }
    }

    class MagicBackpage<T> where T:MagicItem,new()
    {
        public T GetItem()
        {
            Console.WriteLine($"从包里拿出来了{typeof(T).Name}");
            return new T();
        }
    }

    class Test<T, K> where T : class where K : struct
    { 
    
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region 泛型约束
            //var sward = new MagicBackpage<Sword>();
            //sward.GetItem().Use();

            //var potion=new MagicBackpage<Potion>();
            //potion.GetItem().Use();

            //var potion2 = new MagicBackpage<Frog>();
            //potion2.GetItem().Ribbit();
            #endregion

            #region List中提前设置容量Capasity的探究
            listCapasity();
            #endregion
        }

        static void listCapasity()
        {
            int numberOfItem = 10000;

            List<int> listwithoutC=new List<int> ();

            var Without_startTime = DateTime.Now;

            for (int i = 0; i < numberOfItem; i++)
            {
                listwithoutC.Add (i);
            }
            var Without_endTime = DateTime.Now;
            Console.WriteLine($"不预设容量用时:{(Without_endTime-Without_startTime).TotalMilliseconds}");

            List<int> listC = new List<int>();

            var _startTime = DateTime.Now;

            for (int i = 0; i < numberOfItem; i++)
            {
                listC.Add(i);
            }
            var _endTime = DateTime.Now;
            Console.WriteLine($"预设容量用时:{(_endTime - _startTime).TotalMilliseconds}");

        }
    }
}
