using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;


namespace Delegate
{
    delegate void Help();

    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary <string , int>  dic_test = new Dictionary<string, int>();
            
            dic_test.Add("apple",4);
            dic_test.Add("banana",6);
            dic_test.Add("juice",7);
            dic_test.Add("orange",8);
            
            //尝试添加apple或修改apple的value
            Console.WriteLine(dic_test.TryAdd("apple", 9) ? "successful to add apple" : "failed to add apple");
            
            //直接修改apple的value
            Console.WriteLine(dic_test["apple"]) ;//改之前
            dic_test["apple"] = 8;
            Console.WriteLine(dic_test["apple"]) ;//改之后
            
            
            

            if (dic_test.TryGetValue("apple", out int A_price))
            {
                Console.WriteLine("apple price is {0}", A_price);
            }
            else
            {
                Console.WriteLine("not found");
            }




            foreach (var item in dic_test)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
            
            foreach (var item in dic_test.Keys)
            {
                Console.WriteLine(item);
            }
            
            foreach (var item in dic_test.Values)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}