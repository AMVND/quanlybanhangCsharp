using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBANHANG
{
    internal class clmathang
    {
        private string s="";

        public clmathang()
        {
            s = ConfigurationManager.ConnectionStrings["Strconnection"].ConnectionString;
        }
        private void HienThiDL()
        {
            SqlConnection con = new SqlConnection(s);
            DataSet ds = new DataSet();
            String sql = "Select * from tblMathang";
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
            CommandType comm = new CommandType();

        }
        public void addmathang(string masp, string tensp, string donvi, string dongia,string ngaysx, string ngayhh, string ghichu)
        {
            
            string sqlinsert = "insert into tblMathang values(N'" + masp + "','" + tensp + "'," + ngaysx + "'," + ngayhh + "',N'" + donvi + "','" + dongia + "',N'" + ghichu + "')";
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            SqlCommand comm = new SqlCommand(sqlinsert, conn);
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
        }
        public void delmathang(string masp, string tensp, string ngaysx, string ngayhh, string donvi, string dongia, string ghichu)
        {
            string sqldel = "delete from tblMathang where masp like N'" + masp + "'";
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            SqlCommand comm = new SqlCommand(sqldel, conn);
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            conn.Close();
        }
        public void updatemathang(string masp, string tensp, string ngaysx, string ngayhh, string donvi, string dongia, string ghichu)
        {

            string sqldel = "update tblMathang set masp=N'" + masp + "', tensp=N'" + tensp + "', ngaysx=N'" + ngaysx + "' where masp like N'" + masp + "'";
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            SqlCommand comm = new SqlCommand(sqldel, conn);
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            conn.Close();
        }

    }
}
