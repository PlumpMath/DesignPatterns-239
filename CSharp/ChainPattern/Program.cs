using System;
using System.Collections.Generic;
using System.Text;

namespace ChainPattern
{
    abstract class Manager
    {
        protected string name;
        protected Manager superior;
        public Manager(string name)
        {
            this.name = name;
        }
        public void SetSuperior(Manager superior)
        {
            this.superior = superior;
        }
        abstract public void RequestApplications(Request request);
    }
    class Request
    {
        private string requestType;
        public string RequestType
        {
            get { return requestType; }
            set { requestType = value; }
        }
        private string requestContent;
        public string RequestContent
        {
            get { return requestContent; }
            set { requestContent = value; }
        }
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }
    class CommonManager : Manager
    {
        public CommonManager(string name)
            : base(name)
        {

        }
        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 2)
            {
                Console.WriteLine("{0}:{1}数量{2}被批准", name, request.RequestContent, request.Number);
            } 
            else
            {
                if (superior != null)
                {
                    superior.RequestApplications(request);
                }
            }
        }
    }
    class MajorDemo : Manager
    {
        public MajorDemo(string name)
            : base(name)
        {

        }
        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 5)
            {
                Console.WriteLine("{0}:{1}数量{2}被批准", name, request.RequestContent, request.Number);
            }
            else
            {
                if (superior != null)
                {
                    superior.RequestApplications(request);
                }
            }
        }
    }
    class GeneralManager : Manager
    {
        public GeneralManager(string name)
            : base(name)
        {

        }
        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假")
            {
                Console.WriteLine("{0}:{1}数量{2}被批准", name, request.RequestContent, request.Number);
            }
            else if (request.RequestType == "加薪" && request.Number <= 500)
             {
                 Console.WriteLine("{0}:{1}数量{2}被批准", name, request.RequestContent, request.Number);
             }
            else if (request.RequestType == "加薪" && request.Number > 500)
            {
                Console.WriteLine("{0}:{1}数量{2}再说吧", name, request.RequestContent, request.Number);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CommonManager jinli = new CommonManager("经理");
            MajorDemo zongjian = new MajorDemo("总监");
            GeneralManager zhongjianli = new GeneralManager("总经理");
            jinli.SetSuperior(zongjian);
            zongjian.SetSuperior(zhongjianli);

            Request request = new Request();
            request.RequestType = "加薪";
            request.RequestContent = "小菜要求加薪";
            request.Number = 1;
            jinli.RequestApplications(request);
        }
    }
}
