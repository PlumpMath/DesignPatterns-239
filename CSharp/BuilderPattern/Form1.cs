using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BuilderPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Yellow);
            PersonThinBuilder ptb = new PersonThinBuilder(pictureBox1.CreateGraphics(), p);
            PersonDirector pd = new PersonDirector(ptb);
            pd.GreatePerson();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Yellow);
            PersonThinBuilder ptb = new PersonThinBuilder(pictureBox1.CreateGraphics(), p);
            PersonDirector pd = new PersonDirector(ptb);
            pd.GreatePerson();
        }
    }
}
