using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    abstract class FineryComponent
    {
        public abstract void Show();
    }
    class ConcreteFineryComponent: FineryComponent
    {
        public override void Show()
        {
            Console.WriteLine("具体的装扮");
        }
    }
    class FineryDecorator: FineryComponent
    {
        protected FineryComponent finery;
        public override void Show()
        {
            if (finery != null)
            {
                finery.Show();
            }
            //Console.WriteLine("开始进行装扮");
        }
        public void SetFineryComponent(FineryComponent finery)
        {
            this.finery = finery;
        }
    }
    class TShirtsDecorator: FineryDecorator
    {
        public override void Show()
        {
            base.Show();
            Console.WriteLine("大T恤");
        }
    }
    class  BigTrouserDecorator: FineryDecorator
    {
        public override void Show()
        {
            base.Show();
            Console.WriteLine("垮裤");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteFineryComponent cfc = new ConcreteFineryComponent();
            TShirtsDecorator ts = new TShirtsDecorator();
            BigTrouserDecorator bt = new BigTrouserDecorator();

            ts.SetFineryComponent(cfc);
            bt.SetFineryComponent(ts);
            bt.Show();
        }
    }
}
