using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    class SubsystemOne
    {
        public void Method()
        {
            Console.WriteLine("子系统方法一");
        }
    }
    class SubsystemTwo
    {
        public void Method()
        {
            Console.WriteLine("子系统方法二");
        }
    }
    class SubsystemThree
    {
        public void Method()
        {
            Console.WriteLine("子系统方法三");
        }
    }
    class SubsystemFour
    {
        public void Method()
        {
            Console.WriteLine("子系统方法四");
        }
    }
    class Facade
    {
        SubsystemOne one;
        SubsystemTwo two;
        SubsystemThree three;
        SubsystemFour four;
        public Facade()
        {
            one = new SubsystemOne();
            two = new SubsystemTwo();
            three = new SubsystemThree();
            four = new SubsystemFour();
        }
        public void MethodA()
        {
            Console.WriteLine("\n方法组A------");
            one.Method();
            two.Method();
            three.Method();
        }
        public void MethodB()
        {
            Console.WriteLine("\n方法组B------");
            four.Method();
            two.Method();
            three.Method();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            Console.ReadLine();
        }
    }
}
