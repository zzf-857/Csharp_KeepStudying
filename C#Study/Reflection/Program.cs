using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;


namespace Reflection
{

    class Test
    {
        private int i = 1;
        public int j = 0;
        public string str = "123";
        public Test()
        {
            Console.WriteLine("无参构造函数");
        }
        public Test(int i)
        { 
            this.i = i;
            Console.WriteLine($"有参构造函数{i}");
        }
        public Test(int i, string str):this(i)
        {
            this.str = str;
            Console.WriteLine($"{i}");
            Console.WriteLine($"{str}");
        }

        public void Speak()
        {
            Console.WriteLine(i);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Type
            int a = 12;
            Type type = a.GetType();
            Type t = typeof(int);
            Type type2 = Type.GetType("System.Int32");

            Console.WriteLine(type);
            Console.WriteLine(t);
            Console.WriteLine(type2);

            //程序集
            Console.WriteLine("程序集");
            Console.WriteLine(type.Assembly);
            Console.WriteLine(t.Assembly);
            Console.WriteLine(type2.Assembly);


            //获取类中所有的公共成员
            Console.WriteLine("*************");
            Type reflection = typeof(Test);
            //Console.WriteLine(reflection);

            //MemberInfo[] infs = reflection.GetMembers();
            //foreach (var item in infs)
            //{
            //    Console.WriteLine(item);
            //}



            //获取所有的构造函数信息
            //ConstructorInfo[] ctors = reflection.GetConstructors();

            //foreach (var item in ctors)
            //{
            //    Console.WriteLine(item);
            //}

            //获取构造函数并执行：
            //获取构造函数传入Type数组 数组中内容按顺序是参数类型
            //执行构造函数传入object数组 表示按顺序传入的参数
            //无参构造调用
            //ConstructorInfo ctor = reflection.GetConstructor(new Type[0]);
            //ctor.Invoke(null);


            ////有参构造函数调用
            //ConstructorInfo ctor2 = reflection.GetConstructor(new Type[] { typeof(int) });
            //ctor2.Invoke(new object[] { 22 });

            ////多参数
            //ConstructorInfo ctor3 = reflection.GetConstructor(new Type[] { typeof(int), typeof(string) });
            //ctor3.Invoke(new object[] { 123, "nihao" });

            //公共的成员变量
            //FieldInfo[] fieldinfo = reflection.GetFields();
            //foreach (var item in fieldinfo)
            //{
            //    Console.WriteLine(item);
            //}

            ////单个对象获取
            //FieldInfo Jfieldinfo = reflection.GetField("j");
            //Console.WriteLine($"单个对象获取{Jfieldinfo}");

            //用反射获取j的值
            //Test test = new Test();
            //test.j = 155;
            //Console.WriteLine(Jfieldinfo.GetValue(test));

            //用反射设置j的值
            //Jfieldinfo.SetValue(test, 999);
            //Console.WriteLine(Jfieldinfo.GetValue(test));


            //获取类的公共成员方法
            //Type strType = typeof(string);
            //MethodInfo[] methods=strType.GetMethods();
            //foreach (var method in methods)
            //{
            //    Console.WriteLine(method);
            //}


            //获取substring方法
            //MethodInfo substr = strType.GetMethod("Substring",
            //    new Type[] { typeof(int), typeof(int) });
            //string mystr = "hello,world!";
            //object print=substr.Invoke(mystr,new object[] { 2,10});
            //Console.WriteLine(print);


            #region Activator
            //实例化一个无参构造函数
            Type acType = typeof(Test);
            Activator.CreateInstance(acType);

            //有参构造函数
            Test tt=Activator.CreateInstance(acType, 88) as Test;
            Console.WriteLine(tt);

            Test tt2 = Activator.CreateInstance(acType, 9999,"sdfasdfasd") as Test;
            Console.WriteLine(tt2);

            #endregion



            #region Assembly

            /*
             程序集类
            主要用来加载其他程序集，加载后才能用Type来使用其他程序集中的信息
            
            如果想要使用不是自己程序集中的内容 需要先加载程序集，如dll文件（库文件）

            简单的把库文件看成一种代码仓库，它提供给使用者一些可以直接拿来用的变量、函数或类
             */

            //语法
            //加载同一个文件夹下的不同程序集
            //Assembly assembly = Assembly.Load("程序集名称");

            //加载不同文件下的其他程序集
            //使用@符号可以忽略转义字符
            //Assembly assembly2 = Assembly.LoadFrom("包含程序集清单的文件的完整名称或路径");
            //Assembly assembly3 = Assembly.LoadFile("要加载的文件的完全限定路径");


            //类库文件就是一个纯写代码（算法逻辑）的地方，可以被其他程序引用或者通过反射调用，它最后生成一个dll文件

            #endregion



        }
    }
}
