using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    class Operation
    {
        public double numberA = 0;
        public double NumberA
        {
            get { return numberA; }
            set { numberA = value; }
        }
        public double numberB = 0;
        public double NumberB
        {
            get { return numberB; }
            set { numberB = value; }
        }
        public virtual double GetResult()
        {
            return 0;
        }
    }
    class AddOperation : Operation
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
    class SubOperation : Operation
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
    class MulOperation : Operation
    {
        public override double GetResult()
        {
            return NumberA * NumberB;
        }
    }
    class DivOperation : Operation
    {
        public override double GetResult()
        {
            if (NumberB == 0)
                throw new Exception("除数不能为0");
            return NumberA / NumberB;
        }
    }
    class OperationFactory
    {
        public static Operation CreateOperation(string oper)
        {
            Operation operation = null;
            switch (oper)
            {
                case "+":
                    operation = new AddOperation();
                    break;
                case "-":
                    operation = new SubOperation();
                    break;
                case "*":
                    operation = new MulOperation();
                    break;
                case "/":
                    operation = new DivOperation();
                    break;
                default:
                    break;
            }
            return operation;
        }  
    }
    interface IFactory
    {
        Operation CreateOperation();
    }
    class AddFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new AddOperation();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IFactory operationFactory = new AddFactory();
                Operation operation = operationFactory.CreateOperation();
                operation.NumberA = 1;
                operation.numberB = 5;
                double result = operation.GetResult();
                Console.WriteLine("{0}", result);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("您的输入有错: " + ex.Message);
            }
           
        }
    }
}
