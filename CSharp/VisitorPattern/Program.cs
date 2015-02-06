using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern
{
    abstract class Action
    {
        public abstract void GetManConclusion(Man concreteElementA);
        public abstract void GetWomanConclusion(Woman concreteElementB);
    }
    abstract class Person
    {
        public abstract void Accept(Action visitor);
    }
    class Success:Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine("{0} {1}时，背后多半是个伟大的女人。", concreteElementA.GetType().Name, this.GetType().Name);
        }
        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine("{0} {1}时，背后大多是个不成功的男人。", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }
    class Man : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetManConclusion(this);
        }
    }
    class Woman : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetWomanConclusion(this);
        }
    }
    class ObjectStructure
    {
        private IList<Person> elements = new List<Person>();
        public void Attach(Person element)
        {
            elements.Add(element);
        }
        public void Detach(Person element)
        {
            elements.Remove(element);
        }
        public void Display(Action visitor)
        {
            foreach (Person e in elements)
            {
                e.Accept(visitor);
            }
        }
    }
    class Program
    {
        public static void permute(String str)
        {
            int length = str.Length;
            Boolean[] used = new Boolean[length];
            StringBuilder str_out = new StringBuilder();
            char[] str_in = str.ToCharArray();
            doPermute(str_in, str_out, used, length, 0);
        }
        public static void doPermute(char[] str_in, StringBuilder str_out, Boolean[] used, int length, int level)
        {
            if (level == length)
            {
                Console.WriteLine(str_out.ToString());
                return;
            }
            for (int i = 0; i < length; ++i )
            {
                if (used[i])
                    continue;
                str_out.Append(str_in[i]);
                used[i] = true;
                doPermute(str_in, str_out, used, length, level + 1);
                used[i] = false;
            }
        }
        static void Main(string[] args)
        {
            //ObjectStructure o = new ObjectStructure();
            //o.Attach(new Man());
            //o.Attach(new Woman());

            //Success v1 = new Success();
            //o.Display(v1);

            String str = "hat";
            permute(str);
        }
    }
}
