﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//自己实现一个单链表
namespace LinkedList
{
    #region 单链表实现


    /// <summary>
    /// 不同的节点
    /// </summary>
    /// <typeparam name="T">节点类型</typeparam>
    class LinkedNode<T>
    {
        public T value;//内容或数据

        public LinkedNode<T> nextNode;//下一个节点

        public LinkedNode(T value)
        {
            this.value = value;
            this.nextNode = null;
        }
    }

    /// <summary>
    /// 单向链表类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList<T>
    {
        public LinkedNode<T> head;//头节点
        public LinkedNode<T> last;//尾节点

        public LinkedList()
        {
            head = null;
            last = null;
        }

        /// <summary>
        /// 往链表增加节点
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            LinkedNode<T> node = new LinkedNode<T>(value);//创建新节点

            //当头节点为空（证明这个链表中无内容），则当前节点即使头节点也是尾节点
            if (head == null)
            {

                head = node;
                last = node;
            }
            else
            {
                last.nextNode = node;//将新节点添加到链表的末尾

                last = node;//更新尾节点的引用
            }
        }

        /// <summary>
        /// 移除链表中的节点
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            if (head == null)
            {
                return;
            }
            if (head.value.Equals(value))
            {
                head = head.nextNode;//当头节点为空，则当前节点为头节点
                if (head == null)
                {
                    last = null;
                }
                return;
            }

            LinkedNode<T> node = head;

            while (node.nextNode != null)
            {
                if (node.nextNode.value.Equals(value))
                {
                    node.nextNode = node.nextNode.nextNode;
                    //如果要删除的节点是最后一个节点，则更新尾节点为当前节点
                    if (node.nextNode == last) last = node;
                    return;
                }
                node = node.nextNode;
            }

            if (head == last && head.value.Equals(value))
            {
                head = null;
                last = null;
            }
        }
    }
    #endregion

    #region 自定义List排序
    class Item : IComparable<Item>
    {
        public int ID;
        public Item(int id)
        {
            this.ID = id;
        }

        public int CompareTo(Item other)
        {
            //小于零在前面（左边），大于零在后面（右边）绘制坐标轴来看

            return this.ID > other.ID ? 1 : -1;//升序排列
            //return this.ID >other.ID ? -1 : 1;//降序排列
        }
    }

    #endregion

    #region 委托排序
    class ShopItem
    {
        public int ID;
        public ShopItem(int id)
        {
            this.ID = id;
        }
    }
    #endregion


    #region 协变逆变

    public class Human
    {
        public Human()
        {
            Console.WriteLine("Human构造函数");
        }
    }

    public class Chinese : Human
    {
        public Chinese()
        {
            Console.WriteLine("Chinese构造函数");
        }
    }

    public interface ISport<in T>
    {
        //协变out
        //T Method1();

        //逆变in
        void Method2(T value);
    }

    public class Sport<T> : ISport<T> where T : new()
    {
        public T Method1()
        {
            Console.WriteLine("协变");

            //return new T();
            return default(T);
        }
        public void Method2(T value)
        {
            Console.WriteLine("逆变");
        }
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            //Test();

            //mySelfSort();

            //delegateSort();


            //xieBian();

            niBian();
        }
        static void Test()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            LinkedNode<int> node = linkedList.head;

            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }

            //这里有问题？？移除最后一个添加不了新元素
            Console.WriteLine("移除5");
            linkedList.Remove(5);

            node = linkedList.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }

            Console.WriteLine("移除1");
            linkedList.Remove(1);
            node = linkedList.head;

            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }

            Console.WriteLine("移除3");
            linkedList.Remove(3);

            node = linkedList.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }

            Console.WriteLine("增加99");
            linkedList.Add(99);
            node = linkedList.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }
        }

        #region 自定义排序
        static void mySelfSort()
        {
            List<Item> itemList = new List<Item>();
            itemList.Add(new Item(1));
            itemList.Add(new Item(2));
            itemList.Add(new Item(3));
            itemList.Add(new Item(4));
            itemList.Add(new Item(5));

            itemList.Sort();

            foreach (var item in itemList)
            {
                Console.WriteLine(item.ID);
            }
        }
        #endregion


        #region 使用委托排序

        //普通方式
        //static void delegateSort()
        //{
        //    List<ShopItem> shopItemList = new List<ShopItem>();
        //    shopItemList.Add(new ShopItem(1));
        //    shopItemList.Add(new ShopItem(2));
        //    shopItemList.Add(new ShopItem(3));
        //    shopItemList.Add(new ShopItem(4));
        //    shopItemList.Sort(SortShopItem);
        //    foreach (var item in shopItemList)
        //    {
        //        Console.WriteLine($"使用委托排序{item.ID}");
        //    }
        //}
        //static int SortShopItem(ShopItem a, ShopItem b)
        //{
        //    if (a == null || b == null) return 0;
        //    return a.ID > b.ID ? 1 : -1;
        //}


        //使用匿名函数+lambda表达式
        static void delegateSort()
        {
            List<ShopItem> shopItemList = new List<ShopItem>();
            shopItemList.Add(new ShopItem(1));
            shopItemList.Add(new ShopItem(2));
            shopItemList.Add(new ShopItem(3));
            shopItemList.Add(new ShopItem(4));

            shopItemList.Sort((a, b) => a.ID > b.ID ? 1 : -1);

            foreach (var item in shopItemList)
            {
                Console.WriteLine($"使用委托+lambda表达式+匿名函数排序{item.ID}");
            }
        }

        #endregion


        //static void xieBian()
        //{
        //    ISport<Human> sport = new Sport<Chinese>();
        //    var temp = sport.Method1();
        //    Console.WriteLine(temp+"1111");
        //}

        static void niBian()
        {
            ISport<Chinese> sport = new Sport<Human>();
            sport.Method2(new Chinese());
        }
    }
}
