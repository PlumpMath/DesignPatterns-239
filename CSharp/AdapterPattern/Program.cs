using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern
{
    abstract class Player
    {
        protected string name;
        public Player(string name)
        {
            this.name = name;
        }
        public abstract void Attack();
        public abstract void Defense();
    }
    class Forwards : Player
    {
        public Forwards(string name):base(name)
        {
        }
        public override void Attack()
        {
            Console.WriteLine("前锋{0}进攻", name);
        }
        public override void Defense()
        {
            Console.WriteLine("前锋{0}防守", name);
        }
    }
    class Center : Player
    {
        public Center(string name)
            : base(name)
        {
        }
        public override void Attack()
        {
            Console.WriteLine("中锋{0}进攻", name);
        }
        public override void Defense()
        {
            Console.WriteLine("中锋{0}防守", name);
        }
    }
    class Gurads : Player
    {
        public Gurads(string name)
            : base(name)
        {
        }
        public override void Attack()
        {
            Console.WriteLine("后卫{0}进攻", name);
        }
        public override void Defense()
        {
            Console.WriteLine("后卫{0}防守", name);
        }
    }
    class ForeignCenter
    {
        string 名字;
        public string Name
        {
            get { return 名字; }
            set { 名字 = value; }
        }
        public ForeignCenter()
        {
        }
        public void 进攻()
        {
            Console.WriteLine("外籍中锋{0}进攻", 名字);
        }
        public void 防守()
        {
            Console.WriteLine("外籍中锋{0}防守", 名字);
        }
    }
    class Interpreter : Player
    {
        private ForeignCenter foreignCenter = new ForeignCenter();
        public Interpreter(string name)
            : base(name)
        {
            foreignCenter.Name = name;
        }
        public override void Attack()
        {
            foreignCenter.进攻();
        }
        public override void Defense()
        {
            foreignCenter.防守();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player b = new Forwards("巴蒂尔");
            b.Attack();
            Player m = new Gurads("麦克格雷迪");
            b.Defense();

            Player y = new Interpreter("姚明");
            y.Attack();
        }
    }
}
