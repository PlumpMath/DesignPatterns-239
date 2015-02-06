using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPattern
{
    interface IGiveGift
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();
    }
    class SchoolGirl
    {
        private string name;
        public string Name
        {
            get{return name;}
            set{name = value;}

        }
    }
    class Pursuit : IGiveGift
    {
        SchoolGirl mm;
        public Pursuit(SchoolGirl mm)
        {
            this.mm =mm;
        }
        public void GiveDolls()
        {
            Console.WriteLine(mm.Name + "送你洋娃娃");
        }
        public void GiveChocolate()
        {
            Console.WriteLine(mm.Name + "送你巧克力");
        }
        public void GiveFlowers()
        {
            Console.WriteLine(mm.Name + "送你鲜花");
        }
    }
    class Proxy : IGiveGift
    {
        Pursuit gg;
        public Proxy(SchoolGirl mm)
        {
            gg = new Pursuit(mm);
        }
        public void GiveDolls()
        {
            gg.GiveDolls();
        }
        public void GiveChocolate()
        {
            gg.GiveChocolate();
        }
        public void GiveFlowers()
        {
            gg.GiveFlowers();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SchoolGirl jiaojiao = new SchoolGirl();
            jiaojiao.Name = "杨阳";

            Proxy daili = new Proxy(jiaojiao);
            daili.GiveDolls();
            daili.GiveChocolate();

            daili.GiveFlowers();

        }
    }
}
