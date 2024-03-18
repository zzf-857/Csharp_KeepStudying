using System;
using System.Collections.Generic;
using System.Linq;


namespace Genericity
{
    class Program
    {
        static void Main(string[] args)
        {
            // Apple apple = new Apple() { number = 23 };
            // Book book = new Book() { Name = "哈利波特" };
            // Box<Apple> apple1 = new Box<Apple>() { Value = apple};
            // Box<Book> book1 = new Box<Book>() { Value = book};
            // Console.WriteLine(apple1.Value.number+"."+apple1.Value.Cn);
            // Console.WriteLine(book1.Value.Name);

            Func<int, int> doubleIt = x => x * 2;
            Console.WriteLine(doubleIt(23));
            
            
            
            List<string> fruits = new List<string> { "Banana", "Cherry", "Orange", "Apple"};

// 使用 Where 方法进行筛选
            var result = fruits.Where(StartsWithA);

// 筛选函数
            static bool StartsWithA(string fruit)
            {
                return fruit.StartsWith("A");
            }

// 输出筛选结果
            foreach (var fruit in result)
            {
                Console.Write(fruit + " "); // 输出：Apple
            }
            
            
            
        }
        
    }

    class Apple
    {
        public int number { get; set; }
        public string Cn { get; set; } 
        
    }
    
    class Book
    {
        public string Name { get; set; }
    }
    class Box<T>
    {
        public T Value { get; set; }
    }


}