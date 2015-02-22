using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace InterpreterPattern
{
    class PlayContext
    {
        private string text;
        public string PlayText
        {
            get { return text; }
            set { text = value; }
        }
    }
    abstract class Expression
    {
        public void Interpret(PlayContext context)
        {
            if (context.PlayText.Length == 0)
            {
                return;
            } 
            else
            {
                string PlayKey = context.PlayText.Substring(0, 1);
                context.PlayText = context.PlayText.Substring(2);
                double playValue = Convert.ToDouble(context.PlayText.Substring(0, context.PlayText.IndexOf(" ")));
                context.PlayText = context.PlayText.Substring(context.PlayText.IndexOf(" ") + 1);
                Execute(PlayKey, playValue);
            }
        }
        public abstract void Execute(string key, double value);
    }
    class Note : InterpreterPattern.Expression
    {
        public override void Execute(string key, double value)
        {
            string note = "";
            switch (key)
            {
                case "C":
                    note = "1";
                    break;
                case "D":
                    note = "2";
                    break;
                case "E":
                    note = "3";
                    break;
                case "F":
                    note = "4";
                    break;
                case "G":
                    note = "5";
                    break;
                case "A":
                    note = "6";
                    break;
                case "B":
                    note = "7";
                    break;
            }
            Console.WriteLine("{0} ", note);
        }
    }
    class Scale : Expression
    {
        public override void Execute(string key, double value)
        {
            string sacle = "";
            switch (Convert.ToInt32(value))
            {
                case 1:
                    sacle = "低音";
                    break;
                case 2:
                    sacle = "中音";
                    break;
                case 3:
                    sacle = "高音";
                    break;
            }
            Console.WriteLine("{0} ", sacle);
        }
    }
    class ExpressionFactory
    {
        private static readonly string assemblyName = "InterpreterPattern";
        public static Expression CreateExpression(string str)
        {
            string expname = "";
            switch (str)
            {
                case "O":
                    expname = "Scale";     
                    break;
                case "C":
                case "D":
                case "E":
                case "F":
                case "G":
                case "A":
                case "B":
                    expname = "Note";
                    break;
            }
            string classname = assemblyName + "." + expname;
            return (Expression)Assembly.Load(assemblyName).CreateInstance(classname); ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PlayContext context = new PlayContext();
            Console.WriteLine("上海滩： ");
            context.PlayText = "O 2 E 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 A 0.5 O 3 C 1 O 1 A 0.5 G 1 C 0.5 E 0.5 D 3";
            
            try
            {
                while (context.PlayText.Length > 0)
                {
                    string str = context.PlayText.Substring(0, 1);
                    Expression expression = ExpressionFactory.CreateExpression(str);
                    //switch (str)
                    //{
                    //    case "O":
                    //        expression = new Sacle();
                    //        break;
                    //    case "C":
                    //    case "D":
                    //    case "E":
                    //    case "F":
                    //    case "G":
                    //    case "A":
                    //    case "B":
                    //        expression = new Note();
                    //        break;
                    //}
                    expression.Interpret(context);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
