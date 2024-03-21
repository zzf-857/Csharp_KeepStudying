using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudy
{
     class Extend
    {

    }

     public class Human
    {
        public string Describe { get; set; }
        public Human(string str)
        {
            Describe = str;
            Console.WriteLine("Human传入的方法："+ Describe);
        }
    }

    public class Teacher:Human
    {
        public Teacher(string str):base(str)
        {
            Describe = str;
            Console.WriteLine("Teacher实例化"+Describe);
        }
    }
}
