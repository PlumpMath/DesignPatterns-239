using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    abstract class Company
    {
        protected string name;
        public Company(string name)
        {
            this.name = name;
        }
        public abstract void Display(int depth);
        public abstract void Add(Company c);
        public abstract void Remove(Company c);
        public abstract void LineOfDuty();
    }
    class ConcreteCompany : Company
    {
        public ConcreteCompany(string name) : base(name)
        { }
        public override void Add(Company c)
        {
            children.Add(c);
        }
        public override void Remove(Company c)
        {
            children.Remove(c);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
            foreach (Company component in children)
            {
                component.Display(depth + 2);
            }
        }
        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 公司总体运营", name);
            foreach (Company component in children)
            {
                component.LineOfDuty();
            }
        }
        public List<Company> children = new List<Company>();
    }
    class HRDepartment : Company
    {
        public HRDepartment(string name)
            : base(name)
        {

        }
        public override void Add(Company c)
        {
            
        }
        public override void Remove(Company c)
        {
            
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 员工招聘管理", name);
        }
    }
    class FinaceDepartment : Company
    {
        public FinaceDepartment(string name)
            : base(name)
        {

        }
        public override void Add(Company c)
        {

        }
        public override void Remove(Company c)
        {

        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 公司财务收支管理", name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Company root = new ConcreteCompany("北京总公司");
            root.Add(new HRDepartment("总公司人力资源部"));
            root.Add(new FinaceDepartment("总公司财务部"));
            Company comp = new ConcreteCompany("上海华东分公司");
            comp.Add(new HRDepartment("华东分公司人力资源一部"));
            comp.Add(new HRDepartment("华东分公司人力资源二部"));
            comp.Add(new FinaceDepartment("华东分公司财务部"));
            root.Add(comp);


            Console.WriteLine("公司结构图：");
            root.Display(1);
            Console.WriteLine("\n职责：");
            root.LineOfDuty();
        }
    }
}
