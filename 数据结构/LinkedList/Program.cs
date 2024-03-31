using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//自己实现一个单链表
namespace LinkedList
{
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
    internal class Program
    {
        static void Main(string[] args)
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


    }
}
