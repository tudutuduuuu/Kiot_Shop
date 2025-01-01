using BusinessLayer;
using DataLayer;
using System;

namespace STOCK
{
    public partial class frmDonVi : DevExpress.XtraEditors.XtraForm
    {
        public frmDonVi()
        {
            InitializeComponent();
        }

        BusinessLayer.DONVI _dvi;
        BusinessLayer.CONGTY _cty;
        bool _them;
        string _maDonVi;

        private void frmDonVi_Load(object sender, EventArgs e)
        {
            _dvi = new BusinessLayer.DONVI();
            _cty = new BusinessLayer.CONGTY();
            loadData();
            //loadCongTy();
            showHideControl(true);
            //_enabled(false);
            //txtMa.Enabled = false;
            //cboCty.SelectedIndexChanged += CboCty_SelectedIndexChanged;
            //loadDviByCty();
        }

        void loadData()
        {
            gcDanhSach.DataSource = _dvi.GetAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void showHideControl(bool t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnThoat.Enabled = t;
            btnLuu.Enabled = !t;
            btnBoQua.Enabled = !t;
        }

        void _enabled(bool t)
        {
            txtTen.Enabled = t;
            txtDienThoai.Enabled = t;
            txtFax.Enabled = t;
            txtEmail.Enabled = t;
            txtDiaChi.Enabled = t;
            chkDisabled.Enabled = t;
        }

        void _reset()
        {
            txtTen.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            chkDisabled.Checked = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            showHideControl(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                DataLayer.DONVI dvi = new DataLayer.DONVI();
                dvi.MADVI = txtMaDonVi.Text;
                dvi.TENDVI = txtTen.Text;
                dvi.DIACHI = txtDiaChi.Text;
                dvi.DIENTHOAI = txtDienThoai.Text;
                dvi.FAX = txtFax.Text;
                dvi.EMAIL = txtEmail.Text;
                dvi.DISABLED = chkDisabled.Checked;
                _dvi.Add(dvi);
            }
            else
            {
                DataLayer.DONVI dvi = _dvi.GetItem(_maDonVi);
                dvi.MADVI = label6.Text;
                dvi.TENDVI = txtTen.Text;
                dvi.DIACHI = txtDiaChi.Text;
                dvi.DIENTHOAI = txtDienThoai.Text;
                dvi.FAX = txtFax.Text;
                dvi.EMAIL = txtEmail.Text;
                dvi.DISABLED = chkDisabled.Checked;
                _dvi.Update(dvi);
            }
            _them = false;
            loadData();
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maDonVi=gvDanhSach.GetFocusedRowCellValue("MADVI").ToString();
                txtMaDonVi.Text = gvDanhSach.GetFocusedRowCellValue("MADVI").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENDVI").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("").ToString();
            }
        }
    }
}