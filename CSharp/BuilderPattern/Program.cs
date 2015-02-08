using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace BuilderPattern
{
    abstract class PersonBuilder
    {
        protected Graphics g;
        protected Pen p;
        public PersonBuilder(Graphics g, Pen p)
        {
            this.p = p;
            this.g = g;
        }
        public abstract void BuildHead();
        public abstract void BuildBody();
        public abstract void BuildLeftArm();
        public abstract void BuildRightArm();
        public abstract void BuildLeftLeg();
        public abstract void BuildRightLeg();
    }

    class PersonThinBuilder: PersonBuilder
    {
        public PersonThinBuilder(Graphics g, Pen p)
            : base(g, p)
        {

        }
        public override void BuildHead()
        {
            g.DrawEllipse(p, 50, 20, 30, 30);
        }
        public override void BuildBody()
        {
            g.DrawRectangle(p, 60, 50, 10, 30);
        }
        public override void BuildLeftArm()
        {
            g.DrawLine(p, 60, 50, 40, 100);
        }
        public override void BuildRightArm()
        {
            g.DrawLine(p, 70, 50, 90, 100);
        }
        public override void BuildLeftLeg()
        {
            g.DrawLine(p, 60, 100, 45, 150);
        }
        public override void BuildRightLeg()
        {
            g.DrawLine(p, 70, 100, 85, 150);
        }
    }

    class PersonDirector
    {
        private PersonBuilder pb;
        public PersonDirector(PersonBuilder pb)
        {
            this.pb = pb;
        }
        public void GreatePerson()
        {
            pb.BuildBody();
            pb.BuildHead();
            pb.BuildLeftArm();
            pb.BuildLeftLeg();
            pb.BuildRightArm();
            pb.BuildRightLeg();
        }
    }

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

          
        }
    }
}
