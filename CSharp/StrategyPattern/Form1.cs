using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StrategyPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public double total = 0.0d;
        private void button1_Click(object sender, EventArgs e)
        {
            CashContext csuper = new CashContext(cbxType.SelectedItem.ToString());
            double totalPrices = 0d;
            totalPrices = csuper.GetResult(Convert.ToDouble(txtPrice.Text) *
                Convert.ToDouble(txtNum.Text));
            total = total + totalPrices;
            lbxList.Items.Add("单价： " + txtPrice.Text + " 数量： " + txtNum.Text
                + " " + cbxType.SelectedItem + " 合计： " + totalPrices.ToString());
            lblResult.Text = total.ToString();
            //CashSuper cs = CashFactory.CreateCashAccept(cbxType.SelectedItem.ToString());
            //double totalPrices = 0d;
            //totalPrices = cs.acceptCash(Convert.ToDouble(txtPrice.Text) *
            //    Convert.ToDouble(txtNum.Text));
            //total = total + totalPrices;
            //lbxList.Items.Add("单价： " + txtPrice.Text + " 数量： " + txtNum.Text
            //    + " " + cbxType.SelectedItem + " 合计： " + totalPrices.ToString());
            //lblResult.Text = total.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


    }
}
