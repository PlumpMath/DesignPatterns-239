using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SingletonPattern
{
    public partial class FormToolBox : Form
    {
        private static FormToolBox ftb = null;
        private FormToolBox()
        {
            InitializeComponent();
        }
        public static FormToolBox GetInstance()
        {
            if (ftb == null || ftb.IsDisposed)
            {
                ftb = new FormToolBox();
                ftb.MdiParent = Form1.ActiveForm;
            }
            return ftb;
        }

    }
}
