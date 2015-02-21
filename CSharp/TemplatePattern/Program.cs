using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatPattern
{
    abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("");
        }
    }
    class ConcreteclassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("具体类A方法1实现");
            
        }
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("具体类A方法2实现");
            
        }
    }
    class ConcreteclassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("具体类B方法1实现");
            
        }
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("具体类B方法2实现");
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass c;
            c = new ConcreteclassA();
            c.TemplateMethod();

            c = new ConcreteclassB();
            c.TemplateMethod();

        }
    }
}
