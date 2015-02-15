using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorPattern
{
    abstract class Iterator
    {
        public abstract Object First();
        public abstract Object Next();
        public abstract bool IsDone();
        public abstract Object CuurentItem();
    }
    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
    class ConcreteIterator : Iterator
    {
        private ConcreteAggregate aggregate;
        private int current = 0;
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }
        public override object First()
        {
            return aggregate[0];
        }
        public override object Next()
        {
            object ret = null;
            current++;
            if (current < aggregate.Count)
            {
                ret = aggregate[current];
            }
            return ret;
        }
        public override bool IsDone()
        {
            return current >= aggregate.Count ? true : false;
        }
        public override object CuurentItem()
        {
            return aggregate[current];
        }
    }
    class ConcreteIteratorDesc : Iterator
    {
        private ConcreteAggregate aggregate;
        private int current = 0;
        public ConcreteIteratorDesc(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
            current = aggregate.Count - 1;
        }
        public override object First()
        {
            return aggregate[aggregate.Count - 1];
        }
        public override object Next()
        {
            object ret = null;
            current--;
            if (current >= 0)
            {
                ret = aggregate[current];
            }
            return ret;
        }
        public override bool IsDone()
        {
            return current < 0 ? true : false;
        }
        public override object CuurentItem()
        {
            return aggregate[current];
        }
    }
    class ConcreteAggregate : Aggregate
    {
        private IList<object> items = new List<object>();
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
        public int Count
        {
            get
            {
                return items.Count;
            }
        }
        public Object this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteAggregate passengers = new ConcreteAggregate();
            passengers[0] = "大鸟";
            passengers[1] = "小菜";
            passengers[2] = "行李";
            passengers[3] = "老外";
            passengers[4] = "公司内部员工";
            passengers[5] = "小偷";

            Iterator iPassenger = new ConcreteIterator(passengers);
            //object item = iPassenger.First();
            while (!iPassenger.IsDone())
            {
                Console.WriteLine("{0}请买票", iPassenger.CuurentItem());
                iPassenger.Next();
            }

            Iterator iPassengerDesc = new ConcreteIteratorDesc(passengers);
            while (!iPassengerDesc.IsDone())
            {
                Console.WriteLine("{0}请买票", iPassengerDesc.CuurentItem());
                iPassengerDesc.Next();
            }
        }
    }
}
