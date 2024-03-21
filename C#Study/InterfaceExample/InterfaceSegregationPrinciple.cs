using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    internal class InterfaceSegregationPrinciple
    {
    }

    class Driver
    {
        private IVehicle _vehicle;
        //构造方法，实例化时候就可以传入
        public Driver(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }
        //对外暴露的一个可供实例调用的方法
        public void Drive()
        {
            _vehicle.Run();
        }
    
    }
    interface IVehicle
    {
       void Run();
    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is Running......");
        }
    }

    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is Running......");
        }
    }
    //违反接口隔离原则，修改
    //interface ITank
    //{
    //    void Run();
    //    void Fire();
    //}

    //使用根据接口隔离原则改动
    interface IWeapon
    {
        void Fire();
    }
    interface ITank :IVehicle,IWeapon
    { 

    }
    class LightTank : ITank
    {
        public void Run()
        {
            Console.WriteLine("LightTank is Running......didididi");
        }

        public void Fire()
        {
            Console.WriteLine("LightTank is Fired......");
        }
    }
    class HavyTank : ITank
    {
        public void Run()
        {
            Console.WriteLine("HavyTank is Running......kongkongkong");
        }

        public void Fire()
        {
            Console.WriteLine("HavyTank is Fired......");
        }
    }



}
