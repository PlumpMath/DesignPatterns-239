using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    class WorkExperience: ICloneable
    {
        private string workDate;
        public string WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }
        private string company;
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        public Object Clone()
        {
            return (Object)this.MemberwiseClone();
        }
    }
    class Resume: ICloneable
    {
        private string name;
        private string sex;
        private string age;
        public string timeArea;
        public string company;
        public WorkExperience work;
        public Resume(string name)
        {
            this.name = name;
            work = new WorkExperience();
        }
        public Resume(WorkExperience work)
        {
            this.work = (WorkExperience)work.Clone();
        }
        public void SetPersonalInfo(string sex, string age)
        {
            this.sex = sex;
            this.age = age;
        }
        public void SetWorkExperience(string workDate, string company)
        {
            work.WorkDate = workDate;
            work.Company = company;
        }
        //public void SetWorkExperience(string timeArea, string company)
        //{
        //    this.timeArea = timeArea;
        //    this.company = company;
        //}
        public void Display()
        {
            Console.WriteLine("姓名：{0}\t性别：{1}\t年龄：{2}", name, sex, age);
            Console.WriteLine("工作经历：{0}\t{1}", work.WorkDate, work.Company);
            //Console.WriteLine("工作经历：{0}\t{1}", timeArea, company);
        }

        public object Clone()
        {
            //return (object)this.MemberwiseClone();
            Resume obj = new Resume(this.work);
            obj.name = this.name;
            obj.age = this.age;
            obj.sex = this.sex;
            return obj;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Resume a = new Resume("大鸟");
            a.SetPersonalInfo("男", "19");
            a.SetWorkExperience("北京", "华为");
            
            Resume b = (Resume)a.Clone();
            Resume c = (Resume)a.Clone();
            a.Display();
            b.Display();
            c.Display();
            c.SetWorkExperience("深圳", "腾讯");
            a.SetWorkExperience("上海", "国际贸易");
            a.Display();
            b.Display();
           
            c.Display();
        }
    }
}
