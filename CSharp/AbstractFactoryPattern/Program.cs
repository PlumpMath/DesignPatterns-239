using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace AbstractFactoryPattern
{
    public class User
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    }

    class SqlserverUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在SQL Server中给User表增加一条记录");
        }
        public User GetUser(int id)
        {
            Console.WriteLine("在SQL Server中根据ID得到User表中的一条记录");
            return null;
        }
    }
    class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在ACCESS中给User表增加一条记录");
        }
        public User GetUser(int id)
        {
            Console.WriteLine("在ACCESS中根据ID得到User表中的一条记录");
            return null;
        }
    }
     interface IFactory
    {
        IUser CreateUser();
        IDepartment CreateDepartment();
    }
    class SqlServerFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new SqlserverUser();
        }
        public IDepartment CreateDepartment()
        {
            return new SqlserverDepartment();
        }
    }
    class AccessFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }
        public IDepartment CreateDepartment()
        {
            return new AccessDepartment();
        }
    }
    class Department
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _departmentName;
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }
    }
    interface IDepartment
    {
        void Insert(Department department);
        Department GetDepartment(int id);
    }
    class SqlserverDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在SQL Server中给Department表增加一条记录");
        }
        public Department GetDepartment(int id)
        {
            Console.WriteLine("在SQL Server中根据ID得到Department表删除一条记录");
            return null;
        }
    }
    class AccessDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在ACCESS中给Department表增加一条记录");
        }
        public Department GetDepartment(int id)
        {
            Console.WriteLine("在ACCESS中根据ID得到Department表删除一条记录");
            return null;
        }
    }
    class DataAccess
    {
        private static readonly string assemblyName = "AbstractFactoryPattern";
        private static readonly string db = ConfigurationManager.AppSettings["DB"];
        /// <summary>
        /// 以下使用反射技术
        /// </summary>
        public static IUser CreateUser()
        {
            string className = assemblyName + "." + db + "User";
            return (IUser)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IDepartment CreateDepartment()
        {
            string className = assemblyName + "." + db + "Department";
            return (IDepartment)Assembly.Load(assemblyName).CreateInstance(className);
        }
        //public static IUser CreateUser()
        //{
        //    IUser result = null;
        //    switch (db)
        //    {
        //        case "Sqlserver":
        //            result = new SqlserverUser();
        //            break;
        //        case "Access":
        //            result = new AccessUser();
        //            break;
        //        default:
        //            break;
        //    }
        //    return result;
        //}
        //public static IDepartment CreateDepartment()
        //{
        //    IDepartment result = null;
        //    switch (db)
        //    {
        //        case "Sqlserver":
        //            result = new SqlserverDepartment();
        //            break;
        //        case "Access":
        //            result = new AccessDepartment();
        //            break;
        //        default:
        //            break;
        //    }
        //    return result;
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Department department = new Department();
            IUser iu = DataAccess.CreateUser();
            IDepartment id = DataAccess.CreateDepartment();
            iu.Insert(user);
            iu.GetUser(1);
            id.Insert(department);
            id.GetDepartment(1);



            
            //IFactory factory = new SqlServerFactory();
            //IUser iu = factory.CreateUser();
            //iu.Insert(user);
            //iu.GetUser(1);
            //IDepartment id = factory.CreateDepartment();
            //id.Insert(department);
            //id.GetDepartment(1);
            Console.Read();

        }
    }
}
