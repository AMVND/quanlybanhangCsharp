using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLBANHANG
{
    public partial class Form1 : Form
    {
        private string s;
        private SqlDataAdapter dap;
        private DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }
        private void HienThiDL()
        {
            dgvKetQua.DataSource = ds.Tables[0];
            dgvKetQua.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amvnd\source\repos\QLBANHANG\QLBanhang.mdf;Integrated Security=True";
            con.Open();
            String sql = "Select * from tblMathang";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
            dgvKetQua.DataSource = ds.Tables[0];
            dgvKetQua.Refresh();
            con.Close();
        }
        private void LoadDuLieu(String sql)
        {
            SqlConnection con = new SqlConnection();
            
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amvnd\source\repos\QLBANHANG\QLBanhang.mdf;Integrated Security=True";
            con.Open(); 
            ds = new DataSet();
            dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
            dgvKetQua.DataSource = ds.Tables[0];
        }
        private void HienChiTiet(Boolean hien)
        {
            txtMaSP.Enabled = hien;
            txtTenSP.Enabled = hien;
            dtpNgayHH.Enabled = hien;
            dtpNgaySX.Enabled = hien;
            txtDonvi.Enabled = hien;
            txtDongia.Enabled = hien;
            txtGhichu.Enabled = hien;
 
            btnLuu.Enabled = hien;
            btnHuy.Enabled = hien;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblTieude.Text = "THÊM MẶT HÀNG";
         
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            dtpNgaySX.Value = DateTime.Today;
            dtpNgayHH.Value = DateTime.Today;
            txtDongia.Text = "";
            txtDonvi.Text = "";
            txtGhichu.Text = "";
            
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //
            btnLuu.Visible = true;
            btnHuy.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblTieude.Text = "SỬA MẶT HÀNG";
           
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            dtpNgaySX.Value = DateTime.Today;
            dtpNgayHH.Value = DateTime.Today;
            txtDongia.Text = "";
            txtDonvi.Text = "";
            txtGhichu.Text = "";
          
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //
            btnLuu.Visible = true;
            btnHuy.Visible = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(s);
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amvnd\source\repos\QLBANHANG\QLBanhang.mdf;Integrated Security=True";
            string sql = "";
             if (con.State != ConnectionState.Open)
                con.Open();
            { 
                //Insert
                sql = "INSERT INTO tblMatHang(MaSP,TenSP,NgaySX,NgayHH,DonVi,DonGia,GhiChu)VALUES (";
                sql += "N'" + txtMaSP.Text + "',N'" + txtTenSP.Text + "','" + dtpNgaySX.Value.Date + "','" + dtpNgayHH.Value.Date + "',N'" + txtDonvi.Text + "',N'" + txtDongia.Text + "',N'" + txtGhichu.Text + "')";
            }
            if (btnSua.Enabled == true)
            {
                sql = "Update tblMatHang SET ";
                sql += "TenSP = N'" + txtTenSP.Text + "',";
                sql += "NgaySX = '" + dtpNgaySX.Value.Date + "',";
                sql += "NgayHH = '" + dtpNgayHH.Value.Date + "',";
                sql += "DonVi = N'" + txtDonvi.Text + "',";
                sql += "DonGia = '" + txtDongia.Text + "',";
                sql += "GhiChu = N'" + txtGhichu.Text + "' ";
                sql += "Where MaSP = N'" + txtMaSP.Text + "'";
            }

            if (btnXoa.Enabled == true)
            {
                sql = "Delete From tblMatHang Where MaSP =N'" + txtMaSP.Text + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            sql = "Select * from tblMatHang";
            LoadDuLieu(sql);
            con.Close();
            HienChiTiet(false);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            lblTieude.Text = "TÌM KIẾM MẶT HÀNG";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            String sql = "SELECT * FROM tblMatHang";
            String dk = "";
            if (txtTimMaSP.Text.Trim() != "")
            {
                dk += " MaSP like '%" + txtTimMaSP.Text + "%'";
            }
            if (txtTimTenSP.Text.Trim() != "" && dk != "")
            {
                dk += " AND TenSP like N'%" + txtTimTenSP.Text + "%'";
            }
            if (txtTimTenSP.Text.Trim() != "" && dk == "")
            {
                dk += " TenSP like N'%" + txtTimTenSP.Text + "%'";
            }
            if (dk != "")
            {
                sql += " WHERE" + dk;
            }
            LoadDuLieu(sql);
        }

        private void dgvKetQua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;

            try
            {
                txtMaSP.Text = dgvKetQua[0, e.RowIndex].Value.ToString();
                txtTenSP.Text = dgvKetQua[1, e.RowIndex].Value.ToString();
                dtpNgaySX.Value = (DateTime)dgvKetQua[2, e.RowIndex].Value;
                dtpNgayHH.Value = (DateTime)dgvKetQua[3, e.RowIndex].Value;
                txtDonvi.Text = dgvKetQua[4, e.RowIndex].Value.ToString();
                txtDongia.Text = dgvKetQua[5, e.RowIndex].Value.ToString();
                txtGhichu.Text = dgvKetQua[6, e.RowIndex].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            lblTieude.Text = "CẬP NHẬT MẶT HÀNG";
            
            btnThem.Enabled = false;
            btnXoa.Enabled = false;

            HienChiTiet(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa mã mặt hàng " + txtMaSP.Text + " không? Nếu có ấn nút Lưu, không thì ấn nút Hủy", "Xóa sản phẩm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lblTieude.Text = "XÓA MẶT HÀNG";
                btnThem.Enabled = false;
                btnSua.Enabled = false;

                HienChiTiet(true);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;

            XoaTrangChiTiet();

            HienChiTiet(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //Đóng form
            this.Close();
        }
        private void XoaTrangChiTiet()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            dtpNgaySX.Value = DateTime.Today;
            dtpNgayHH.Value = DateTime.Today;
            txtDongia.Text = "";
            txtDonvi.Text = "";
            txtGhichu.Text = "";
}
    }
}