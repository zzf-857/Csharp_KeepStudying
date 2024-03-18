using System;

namespace Generic
{
    abstract class Program
    {
        static void Main(string[] args)
        {
            GenericExample();

            Constraint<Human> list = new Constraint<Human>();
            Constraint<Chinese> list2 = new Constraint<Chinese>();
            Constraint<Japanese> list3 = new Constraint<Japanese>();
            Constraint<int> list4 = new Constraint<int>();

            
            TestList<IWriter> testList = new TestList<IWriter>();
            testList.add(new Human());
            testList.add(new Chinese());
            testList.add(new Japanese());
        }
        
        public static void GenericExample()
        {
            //比如我想创建一个int类型的类
            GenericClass<int> genericClass = new GenericClass<int>();
            genericClass._t = 2;
            genericClass._tt = 5;
            int i1 = genericClass._t;
            int i2 = genericClass._tt;
            Console.WriteLine(i1+"  "+i2+"  "+genericClass.GetT(15));

            //比如我想创建一个string类型的类
            GenericClass<string> genericClass2 = new GenericClass<string>();
            genericClass2._t = "hello,";
            genericClass2._tt = "world!";
            string i3 = genericClass2._t;
            string i4 = genericClass2._tt;
            Console.WriteLine(i3+" "+i4+" "+genericClass2.GetT("I'm string!"));
        }
        
        
    }




    /// <summary>
    /// 自定义的泛型类（可以理解为一个模板类）
    /// </summary>
    /// <typeparam name="T">任意类型</typeparam>
    public class GenericClass<T>
    {
        public T _t;
        public T? _tt;
        public T GetT(T t)
        {
            return t;
        }
    }


    public class Human
    {
        public string Name { get; set; }
        
        public string say()
        {
            return "I am a human";
        }
    }

    public interface IWriter
    {
        public void Writer();

    }

    public  class Chinese : Human, IWriter
    {
        public void Writer()
        {
            Console.WriteLine("Hello Chinese can be written!");
        }
    }

    public  class Japanese :  IWriter
    {
        public void Writer()
        {
            Console.WriteLine("Hello Japanese can be written");
        }
    }

    public class Constraint<T> where T : IWriter
    {
        
    }

    public class TestList<U>
    {
        public void add<T>(T item)where T : U
        {
            //do something...
        }
    }
}