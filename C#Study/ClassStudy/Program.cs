using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //基本类的调用
            //BasicClass();

            //普通继承用法
            //Extending();

            Enum();

        }
        static void BasicClass()
        {
            //普通创建
            Student student = new Student() { Name = "普通", Grade = 23 };
            //student.Name = "小明";
            //student.Age = 30;
            student.Respond();


            //反射方式创建类
            Type type = typeof(Student);
            object o = Activator.CreateInstance(type);
            Console.WriteLine(o.GetType());
            //Student stu= o as Student;
            Student stu = (Student)o;
            stu.Name = "反射";
            stu.Grade = 333;
            stu.Respond();

            //动态创建类
            dynamic stu2 = Activator.CreateInstance(type);
            stu2.Name = "动态";
            stu2.Grade = 10000;
            stu2.Respond();
        }


        static void Extending()
        {
            Teacher teacher = new Teacher("这是教师");
            Console.WriteLine(teacher is Human);
            Human human = new Human("外部传入");
        }

        static void Enum()
        {
            FilePermissions a =FilePermissions.FullControl;

            Console.WriteLine(a);
            //Console.WriteLine((int)a);
        }
    }


    class Student
    {
        public static int Amount { get; set; }
        
        static Student()
        {
            Amount = 100;
        }
        //构造函数
        public Student()
        {
            Console.WriteLine("构造函数调用");
            Amount++;
        }
        ~Student()
        {
            Amount--;
        }
        public string Name { get; set; }
        public int Grade { get; set; }

        public void Respond()
        {
            Console.WriteLine($"方法名：{Name},难度等级{Grade},第{Amount}个");
        }
    }



}
