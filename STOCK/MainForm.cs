using BusinessLayer;
using DataLayer;
using DevExpress.XtraNavBar;
using System;
using System.Windows.Forms;

namespace STOCK
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        BusinessLayer.SYS_FUNC _func;

        private void MainForm_Load(object sender, EventArgs e)
        {
            _func = new BusinessLayer.SYS_FUNC();
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

        private void navMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string func_code = e.Link.Item.Tag.ToString();

            //var _group = _sysGroup.GetGroupByMember(_user.IDUSER);
            //var _uRight = _sysRight.GetRight(_user.IDUSER, func_code);

            //if (_group = null)
            //{
            //    var _groupRight = _sysRight.GetRight(_group.GROUP, func_code);
            //    if (_uRight.USER_RIGHT < _groupRight.USER_RIGHT)
            //    {
            //        _uRight.USER_RIGHT = _groupRight.USER_RIGHT
            //    }
            //}

            //if (_uRight.USER_RIGHT == 0)
            //{
            //    MessageBox.Show("Không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            switch (func_code)
            {
                //case "CONGTY":
                //    {
                //        frmCongTy frm = new frmCongTy(_user, _uRight.USER_RIGHT.Value);
                //        frm.ShowDialog();
                //        break;
                //    }
                case "DONVI":
                    {
                        frmDonVi frm = new frmDonVi();
                        frm.ShowDialog();
                        break;
                    }
            }
        //}
        }
    }
}

