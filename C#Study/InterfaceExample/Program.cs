using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //基本接口使用
            //var fan = new DeskFan(new PowerSupply());
            //Console.WriteLine(fan.Work());

            #region 接口隔离原则Interface Segregation Principle
            //InterfaceSegregationPrinciple();
            #endregion

            #region 接口的显示调用和隐式调用
            //ExplicitandHideInterface();
            #endregion
        }

        static void InterfaceSegregationPrinciple()
        {
            Driver driver = new Driver(new Car());
            driver.Drive();
            Driver driver2 = new Driver(new Truck());
            driver2.Drive();
            Driver driver3 = new Driver(new LightTank());
            driver3.Drive();
            Driver driver4 = new Driver(new HavyTank());
            driver4.Drive();
        }

        static void ExplicitandHideInterface()
        {
            WarmKiller wr= new WarmKiller();
            
            wr.Gentle();
            wr.Kill();

            IKiller killer = new WarmKiller();
            killer.Kill();

        }

        static void MyReflection()
        { 
        
        }
    }
    //使用接口解耦
    public interface IPowerSupply
    {
        int GetPower();
    }

    public class PowerSupply : IPowerSupply
    {
        public int GetPower()
        {
            //高耦合
            return 100;
        }
    }
    public class DeskFan
    {
        private IPowerSupply _powerSupply;
        public DeskFan(IPowerSupply powerSupply)
        {
            _powerSupply = powerSupply;
        }

        public string Work()
        {
            int power = _powerSupply.GetPower();
            if (power == 0) { return "Won't Work"; }
            else if (power < 100) { return "Slow"; }
            else if (power < 200) { return "Fast"; }
            else { return "Warnning"; }

        }
    }
}
