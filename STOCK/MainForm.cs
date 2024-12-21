using BusinessLayer;
using DevExpress.XtraNavBar;
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
        SYS_FUNC _func;

        private void MainForm_Load(object sender, EventArgs e)
        {
            _func = new SYS_FUNC();
            leftMenu();
        }

        void leftMenu()
        {
            int i = 0;
            var _IsParent = _func.GetParent();
            foreach (var _pr in _IsParent)
            {
                NavBarGroup navGroup = new NavBarGroup(_pr.DESCRIPTION);
                navGroup.Tag = _pr.FUNC_CODE;
                navGroup.Name = _pr.FUNC_CODE;
                navGroup.ImageOptions.LargeImageIndex = i;
                i++;
                navMain.Groups.Add(navGroup);

                var _IsChild = _func.GetChild(_pr.FUNC_CODE);
                foreach (var _ch in _IsChild)
                {
                    NavBarItem navItem = new NavBarItem(_ch.DESCRIPTION);
                    navItem.Tag = _ch.FUNC_CODE;
                    navItem.Name = _ch.FUNC_CODE;
                    navItem.ImageOptions.SmallImageIndex = 0;
                    navGroup.ItemLinks.Add(navItem);
                }
                navMain.Groups[navGroup.Name].Expanded = true;
            }
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
