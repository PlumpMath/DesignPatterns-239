using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    abstract class Command
    {
        protected Barbecuer receiver;
        public Command(Barbecuer barbecuer)
        {
            this.receiver = barbecuer;
        }
        abstract public void ExecuteCommand();
    }
     class BakeMuttonCommand:Command
    {
         public BakeMuttonCommand(Barbecuer receiver)
             : base(receiver)
         {

         }
         public override void ExecuteCommand()
         {
             receiver.BakeMutton();
         }
    }
     class BakeChickenWingCommand : Command
     {
         public BakeChickenWingCommand(Barbecuer receiver)
             : base(receiver)
         {

         }
         public override void ExecuteCommand()
         {
             receiver.BakeChickenWing();
         }
     }
    class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤羊肉串！");
        }
        public void BakeChickenWing()
        {
            Console.WriteLine("烤鸡翅！");
        }
    }

 
    class Waiter
    {
        private IList<Command> orders = new List<Command>();
        public void SetOrder(Command command)
        {
            if (command.ToString() == "CommandPattern.BakeChickenWingCommand")
            {
                Console.WriteLine("服务员：鸡翅没有了，请点别的烧烤!");
            }
            else
            {
                orders.Add(command);
                Console.WriteLine("增加订单： " + command.ToString() +
                    " 时间： " + DateTime.Now.ToString());
            }
        }
        public void CancelOrder(Command command)
        {
            orders.Remove(command);
            Console.WriteLine("取消订单： " + command.ToString() + " 时间： " + DateTime.Now.ToShortDateString());
        }
        public void Notify()
        {
            foreach (Command cmd in orders)
            {
                cmd.ExecuteCommand();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Barbecuer boy = new Barbecuer();
            Command bakeMuttonCommand1 = new BakeMuttonCommand(boy);
            Command bakeMuttonCommand2 = new BakeMuttonCommand(boy);
            Command bakeMuttonCommand3 = new BakeMuttonCommand(boy);
            Command bakeChickenWindCommand = new BakeChickenWingCommand(boy);
            Waiter girl = new Waiter();

            girl.SetOrder(bakeMuttonCommand1);
            girl.SetOrder(bakeMuttonCommand2);
            girl.SetOrder(bakeMuttonCommand3);
            girl.SetOrder(bakeMuttonCommand2);
            girl.SetOrder(bakeChickenWindCommand);
            girl.CancelOrder(bakeMuttonCommand2);
            girl.Notify();
            Console.ReadLine();
            
        }
    }
}

