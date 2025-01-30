using System;
using System.Drawing;
using System.Windows.Forms;

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
            _enabled(false);
            _reset();
            txtMaDonVi.Enabled = false;
            //cboCty.SelectedIndexChanged += CboCty_SelectedIndexChanged;
            //loadDviByCty();
        }

        /// <summary>
        /// Load data
        /// </summary>
        void loadData()
        {
            gcDanhSach.DataSource = _dvi.GetAll();
            gvDanhSach.OptionsBehavior.Editable = false;
            cboCty.DataSource = _cty.GetAll();
            cboCty.DisplayMember = "TENCTY";
            cboCty.ValueMember = "MACTY";
        }

        /// <summary>
        /// Thực hiện ẩn hiện các button khi thực hiện chức năng
        /// </summary>
        /// <param name="t"></param>
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
            txtMaDonVi.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            chkDisabled.Checked = false;
        }

        /// <summary>
        /// Xử lý thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaDonVi.Enabled = true;
            showHideControl(false);
            _enabled(true);
            _reset();
        }

        /// <summary>
        /// Xử lý sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            txtMaDonVi.Enabled = false;
            showHideControl(false);
        }

        /// <summary>
        /// Xử lý xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _dvi.Delete(_maDonVi);
            }
            loadData();
        }

        /// <summary>
        /// Xử lý lưu và cập nhật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            _enabled(false);
            _reset();
            showHideControl(true);
        }

        /// <summary>
        /// Xử lý bỏ qua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enabled(false);
            txtMaDonVi.Enabled = false;
        }

        /// <summary>
        /// Xử lý thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Xử lý hiển thị data khi chọn 1 record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maDonVi = gvDanhSach.GetFocusedRowCellValue("MADVI")?.ToString() ?? string.Empty;
                txtMaDonVi.Text = gvDanhSach.GetFocusedRowCellValue("MADVI")?.ToString() ?? string.Empty;
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENDVI")?.ToString() ?? string.Empty;
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI")?.ToString() ?? string.Empty;
                txtFax.Text = gvDanhSach.GetFocusedRowCellValue("FAX")?.ToString() ?? string.Empty;
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL")?.ToString() ?? string.Empty;
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI")?.ToString() ?? string.Empty;
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
            }
        }

        /// <summary>
        /// Xử lý khi xóa hiệu lực 1 record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DISABLED" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.bin;
                // Tính tỉ lệ scale dựa trên kích thước ô
                float scale = Math.Min(
                    e.Bounds.Width / (float)img.Width,
                    e.Bounds.Height / (float)img.Height
                );

                // Tính kích thước mới
                int newWidth = (int)(img.Width * scale);
                int newHeight = (int)(img.Height * scale);

                // Tính vị trí để căn giữa
                int x = e.Bounds.X + (e.Bounds.Width - newWidth) / 2;
                int y = e.Bounds.Y + (e.Bounds.Height - newHeight) / 2;

                // Vẽ ảnh
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImage(img, new Rectangle(x, y, newWidth, newHeight));
                e.Handled = true;
            }
        }
    }
}