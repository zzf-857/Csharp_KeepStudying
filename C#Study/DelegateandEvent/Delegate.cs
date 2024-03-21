using System;
using System.Threading.Tasks;

namespace DelegateandEvent
{
    /*委托学习知识点：
    1.委托是一个类，所以一般写在类的外面。写在类内则变为嵌套类
    2.委托根据返回值和参数类型判断是否能够封装方法的
    3.两种使用方式：模板方法(一个通用模板，中间有一处不确定性，使用委托将方法当作参数传进来；不同情况使用不同方法)、回调方法
     */

    internal class Delegate
    {

    }

    #region 基础使用
    public delegate int LKDelegate(int x, int y);

    internal class BasicUse
    {
        public void Run()
        {
            BasicUse calculator = new BasicUse();
            Action action = new Action(calculator.Defualt);
            Func<int, int, int> function1 = new Func<int, int, int>(calculator.Add);
            Func<int, int, int> function2 = new Func<int, int, int>(calculator.Sub);

            //直接调用
            calculator.Defualt();
            Console.WriteLine(calculator.Add(1, 4));
            Console.WriteLine(calculator.Sub(4, 1));


            //通过委托间接调用
            action.Invoke();
            Console.WriteLine(function1.Invoke(3, 5));
            Console.WriteLine(function2.Invoke(3, 5));

            //函数指针式写法
            action();
            Console.WriteLine(function1(3, 5));
            Console.WriteLine(function2(3, 5));




        }



        public void Defualt()
        {
            Console.WriteLine("Defualt方法");
        }
        public int Add(int x, int y)
        {
            Console.WriteLine($"加法调用：{x + y}");
            return x + y;
        }
        public int Sub(int x, int y)
        {
            Console.WriteLine($"减法调用：{x - y}");
            return x - y;
        }
        public int Mul(int x, int y)
        {
            Console.WriteLine($"乘法调用：{x * y}");
            return x * y;
        }
        public int Div(int x, int y)
        {
            Console.WriteLine($"除法调用：{x / y}");
            return x / y;

        }
    }
    #endregion

    #region 多播委托
    class MulticastDelegation
    {
        public void ManyDelegate()
        {
            BasicUse calculator = new BasicUse();
            //多播委托
            LKDelegate newDelegate = new LKDelegate(calculator.Add);
            newDelegate += calculator.Sub;         
            newDelegate += calculator.Mul;
            newDelegate += calculator.Div;
            newDelegate(100, 3);

            //直接调用
            //calculator.Add(100, 3);
            //calculator.Sub(100, 3);
            //calculator.Mul(100, 3);
            //calculator.Div(100, 3);
        }
    }
    #endregion

    #region 泛型委托

    #endregion

    #region 模板方法

    class Productclass
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    class Box
    {
        public Productclass Product { get; set; }
    }
    class WrapFactory
    {
        public Box WrapProduct(Func<Productclass> getProduct)
        {
            Box box = new Box();
            /*           
            Productclass product = getProduct.Invoke();
            box.Product = product;
            */
            box.Product = getProduct.Invoke();
            return box;
        }
    }
    class ProductFactory
    {
        public Productclass MakePizza()
        {
            Productclass product = new Productclass();
            //具体制作过程
            product.Name = "Pizza";
            product.Description = "PizzaDescription";
            return product;
        }
        public Productclass MakeToyCar()
        {
            Productclass product = new Productclass();
            //具体制作过程
            product.Name = "ToyCar";
            product.Description = "ToyCarDescription";

            return product;
        }

        public Productclass MakeBear()
        {
            Productclass product = new Productclass();
            //具体制作过程
            product.Name = "Bear";

            return product;
        }
    }


    /// <summary>
    /// 第二个模板方法
    /// </summary>
    class FoodClass
    {
        public string Name { get; set; }
    }

    class FoodBox
    {
        public FoodClass MadeFood { get; set; }
    }

    class WrapFood
    {
        public FoodBox foodBox(Func<FoodClass> getfood)
        {
            FoodBox box = new FoodBox();
            box.MadeFood = getfood.Invoke();
            return box;

        }
    }

    class Cook
    {
        public FoodClass GBJD()
        {
            FoodClass foodClass = new FoodClass();
            foodClass.Name = "宫保鸡丁";
            return foodClass;

        }

        public FoodClass LJCR()
        {
            FoodClass foodClass = new FoodClass();
            foodClass.Name = "辣椒炒肉";
            return foodClass;
        }
    }
    #endregion



}
