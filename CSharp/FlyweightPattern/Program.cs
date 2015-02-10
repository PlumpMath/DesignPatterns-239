using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FlyweightPattern
{
    class User
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        public User(string name)
        {
            this.name = name;
        }
    }
    abstract class Website
    {
        public abstract void Use(User user);
    }
    class ConcreteWebsite : Website
    {
        private string name;
        public ConcreteWebsite(string name)
        {
            this.name = name;
        }
        public override void Use(User user)
        {
            Console.WriteLine("网站分类： " + name + "\t用户： " + user.Name);
        }
    }
    class WebsiteFactory
    {
        private Hashtable flyweights = new Hashtable();
        public Website GetWebsiteCategory(string key)
        {
            if (!flyweights.ContainsKey(key))
            {
                flyweights.Add(key, new ConcreteWebsite(key));
            }
            return (Website)flyweights[key];
        }
        public int GetWebsiteCount()
        {
            return flyweights.Count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WebsiteFactory f = new WebsiteFactory();
            Website fx = f.GetWebsiteCategory("产品展示");
            fx.Use(new User("小菜"));
            Website fy = f.GetWebsiteCategory("产品展示");
            fy.Use(new User("大鸟"));
            Website fz = f.GetWebsiteCategory("产品展示");
            fz.Use(new User("老顽童"));
            Website fm = f.GetWebsiteCategory("博客");
            fm.Use(new User("桃谷六仙"));
            Website fn= f.GetWebsiteCategory("博客");
            fn.Use(new User("南海鳄神"));
            Console.WriteLine("网站分类总数为：{0}", f.GetWebsiteCount());

            string title1 = "da";
            string title2 = "db";
            Console.WriteLine(Object.ReferenceEquals(title2, title1));
        }
    }
}
