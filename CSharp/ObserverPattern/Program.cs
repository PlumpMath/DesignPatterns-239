using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
//    abstract class Observer
//    {
//        protected string name;
//        protected Subject subject;
//        public Observer(string name, Subject subject)
//        {
//            this.name = name;
//            this.subject = subject;
//        }
//        public abstract void Update();
//    }
    delegate void EventHandler();
    interface Subject
    {
        void Notify();
        string SubjectState
        {
            get;
            set;
        }
    }
    class Boss : Subject
    {
        public event EventHandler Update;
        public string action;
        public void Notify()
        {
            Update();
        }
        public string SubjectState
        {
            get { return action; }
            set { action = value; }
        }
    }
    class StockObserver
    {
        private string name;
        private Subject subject;
        public StockObserver(string name, Subject subject)
        {
            this.name = name;
            this.subject = subject;
        }
        public void CloseStockMarket()
        {
            Console.WriteLine("{0} {1} 关闭股市行情，继续工作！", subject.SubjectState, name);
        }
    }
    class NBAObserver
    {
        private string name;
        private Subject subject;
        public NBAObserver(string name, Subject subject)
        {
            this.name = name;
            this.subject = subject;
        }
        public void CloseNBADirectSeeding()
        {
            Console.WriteLine("{0} {1} 关闭NBA直播，继续工作！", subject.SubjectState, name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Boss huhansan = new Boss();
            StockObserver tongshi1 = new StockObserver("李峰", huhansan);
            NBAObserver  tongshi2 = new NBAObserver("程冰冰", huhansan);

            huhansan.Update += new EventHandler(tongshi1.CloseStockMarket);
            huhansan.Update += new EventHandler(tongshi2.CloseNBADirectSeeding);

            huhansan.SubjectState = "我胡汉三回来了";
            huhansan.Notify();

        }
    }
}
