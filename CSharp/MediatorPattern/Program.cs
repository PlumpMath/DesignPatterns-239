using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern
{
    abstract class UnitedNations
    {
        public abstract void Declare(string message, Country colleague);
    }
    abstract class Country
    {
        protected UnitedNations mediator;
        public Country(UnitedNations mediator)
        {
            this.mediator = mediator;
        }
    }
    class USA : Country
    {
        public USA(UnitedNations mediator)
            : base(mediator)
        {

        }
        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }
        public void GetMessage(string message)
        {
            Console.WriteLine("美国获得对方信息： " + message);
        }
    }
    class Iraq : Country
    {
        public Iraq(UnitedNations mediator)
            : base(mediator)
        {

        }
        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }
        public void GetMessage(string message)
        {
            Console.WriteLine("伊拉克获得对方信息： " + message);
        }
    }
    class UnitedNationsSecurityConcil : UnitedNations
    {
        private USA colleague1;
        public MediatorPattern.USA Colleague1
        {
            set { colleague1 = value; }
        }
        private Iraq colleague2;
        public MediatorPattern.Iraq Colleague2
        {
            set { colleague2 = value; }
        }
        public override void Declare(string message, Country colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.GetMessage(message);
            } 
            else
            {
                colleague1.GetMessage(message);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UnitedNationsSecurityConcil UNSC = new UnitedNationsSecurityConcil();
            USA c1 = new USA(UNSC);
            Iraq c2 = new Iraq(UNSC);
            UNSC.Colleague1 = c1;
            UNSC.Colleague2 = c2;
            c1.Declare("不准研制核武器，否则我发动战争");
            c2.Declare("我们没有核武器，也不怕侵略");
        }
    }
}
