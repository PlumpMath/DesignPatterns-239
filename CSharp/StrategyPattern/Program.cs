using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StrategyPattern
{
   
    public abstract class CashSuper
    {
        public abstract double acceptCash(double money);
    }

    public class CashNormal : CashSuper
    {
        public override double acceptCash(double money)
        {

            return money;
        }
    }

    public class CashRebate : CashSuper
    {
        private double moneyRebate = 1d;
        public CashRebate(string moneyRebate)
        {
            this.moneyRebate = double.Parse(moneyRebate);
        }
        public override double acceptCash(double money)
        {
            return money * moneyRebate;
        }
    }

    public class CashReturn : CashSuper
    {
        private double moneyCondition = 0.0d;
        private double moneyReturn = 0.0d;
        public CashReturn(string moneyCondition, string moneyReturn)
        {
            this.moneyCondition = double.Parse(moneyCondition);
            this.moneyReturn = double.Parse(moneyReturn);
        }
        public override double acceptCash(double money)
        {
            double result = money;
            if (money >= moneyCondition)
            {
                result = money - Math.Floor(money / moneyCondition) * moneyReturn;
            }
            return result;
        }
    }

    public class CashContext
    {
        private CashSuper cs;
        public CashContext(CashSuper csuper)
        {
            this.cs = csuper;
        }
        public CashContext(string type)
        {
            switch(type)
            {
                case "正常收费":
                    cs = new CashNormal();
                    break;
                case "满300返100":
                    cs = new CashReturn("300", "100");
                    break;
                case "打8折":
                    cs = new CashRebate("0.8");
                    break;
            }
            
        }
        public double GetResult(double money)
        {
            return cs.acceptCash(money);
        }
    }

    public class CashFactory
    {
        public static CashSuper CreateCashAccept(string type)
        {
            CashSuper cs = null;
            switch(type)
            {
                case "正常收费":
                    cs = new CashNormal();
                    break;
                case "满300返100":
                    cs = new CashReturn("300", "100");
                    break;
                case "打八折":
                    cs = new CashRebate("0.8");
                    break;
                default:
                    break;
            }
            return cs;

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
