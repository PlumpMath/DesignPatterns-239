using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePattern
{
    abstract class HandsetSoft
    {
        public abstract void Run();
    }
    class HandsetGame : HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("运行手机游戏");
        }
    }
    class HandsetAddressList : HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("运行手机通讯录");
        }
    }
    abstract class HandsetBrand
    {
        protected HandsetSoft soft;
        public void SetHandsetSoft(HandsetSoft soft)
        {
            this.soft = soft;
        }
        public abstract void Run();
    }
    class HandsetBrandM : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }
    class HandsetBrandN : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HandsetBrand ab;
            ab = new HandsetBrandM();
            ab.SetHandsetSoft(new HandsetGame());
            ab.Run();
        }
    }
}
