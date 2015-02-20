using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    abstract class State
    {
        public abstract void WriteProgram(Work w);
    }
    class Work
    {
        public Work()
        {
            current = new ForeNoonState();
        }
        private State current;
        private double hour;
        public double Hour
        {
            get { return hour; }
            set { hour = value; }
        }
        private bool finish = false;
        public bool TaskFinished
        {
            get { return finish; }
            set { finish = value; }
        }
        public void SetState(State s)
        {
            current = s;
        }
        public void WriteProgram()
        {
            current.WriteProgram(this);
        }
    }
    class ForeNoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 12)
            {
                Console.WriteLine("当前时间：{0}点，上午工作，精神百倍", w.Hour);
            }
            else
            {
                w.SetState(new NoonState());
                w.WriteProgram();
            }
        }
    }
    class NoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 13)
            {
                Console.WriteLine("当前时间：{0}点，饿了，午饭；犯困，午休", w.Hour);
            }
            else
            {
                w.SetState(new AfterNoonState());
                w.WriteProgram();
            }
        }
    }
    class AfterNoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 17)
            {
                Console.WriteLine("当前时间：{0}点，下午状态不错，继续努力", w.Hour);
            }
            else
            {
                w.SetState(new EveningState());
                w.WriteProgram();
            }
        }
    }
    class EveningState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.TaskFinished)
            {
                w.SetState(new RestState());
                w.WriteProgram();
            } 
            else
            {
                if (w.Hour < 20)
                {
                    Console.WriteLine("当前时间：{0}点，加班啊，疲惫之极", w.Hour);
                }
                else
                {
                    w.SetState(new GoHomeState());
                    w.WriteProgram();
                }
            }
            
        }
    }
    class SleepState : State
    {
        public override void WriteProgram(Work w)
        {
             Console.WriteLine("当前时间：{0}点，不行了，睡着了", w.Hour);
        }

    }
    class RestState : State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine("当前时间：{0}点，下班回家了", w.Hour);
        }
    }
    class GoHomeState : State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine("当前时间：{0}点，过了20点，必须回家，明天再做吧", w.Hour);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Work emergencyProjects = new Work();
            emergencyProjects.Hour = 22;
            emergencyProjects.TaskFinished = false;
            emergencyProjects.WriteProgram();
        }
    }
}
