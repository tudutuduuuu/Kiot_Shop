﻿using DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace STOCK
{
    public partial class frmConnect : DevExpress.XtraEditors.XtraForm
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        SqlConnection GetCon(string server, string username, string passwd, string database)
        {
            return new SqlConnection(
                "Data Source=" + server + 
                "; Initial Catalog=" + database + 
                "; User ID=" + username + 
                "; Password=" + passwd +
                ";");
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetCon(txtServer.Text, txtUsername.Text, txtPassword.Text, cboDatabase.Text);
            try
            {
                con.Open();
                MessageBox.Show("Kết nối thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string enCryptServ = Encryptor.Encrypt(txtServer.Text, "qwertyuiop", true);
            string enCryptPass = Encryptor.Encrypt(txtPassword.Text, "qwertyuiop", true);
            string enCryptData = Encryptor.Encrypt(cboDatabase.Text, "qwertyuiop", true);
            string enCryptUser = Encryptor.Encrypt(txtUsername.Text, "qwertyuiop", true);

            Connect cn = new Connect(enCryptServ, enCryptUser, enCryptPass, enCryptData);
            cn.SaveFile();
            MessageBox.Show("Lưu file thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboDatabase_Click(object sender, EventArgs e)
        {
            cboDatabase.Items.Clear();
            try
            {
                string Conn = "server=" + txtServer.Text + "; User Id=" + txtUsername.Text + ";pwd=" + txtPassword.Text + ";";
                SqlConnection con = new SqlConnection(Conn);
                con.Open();
                string sql = "select name from sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";
                SqlCommand cmd = new SqlCommand(sql, con);
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboDatabase.Items.Add(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}