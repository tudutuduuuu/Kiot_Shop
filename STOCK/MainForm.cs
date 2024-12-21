using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STOCK
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        DVT _dvt;
        private void MainForm_Load(object sender, EventArgs e)
        {
            _dvt = new DVT();
            gridControl1.DataSource  = _dvt.GetList();
        }
    }
}
