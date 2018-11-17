using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienDAO();
                return instance;
            }
        }

        private NhanVienDAO() { }

        public DataTable DSNhanVien()
        {
            List<BsonDocument> documents = DataProvider.Instance.getDocuments("NhanVien");
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Id");
            dtb.Columns.Add("Ten");
            dtb.Columns.Add("NgaySinh");
            dtb.Columns.Add("GioiTinh");
            dtb.Columns.Add("DiaChi");
            dtb.Columns.Add("Sdt");
            dtb.Columns.Add("Cmnd");
            dtb.Columns.Add("Email");
            foreach (BsonDocument document in documents)
            {
                string id = document["Id"].AsString;
                string ten = document["Ten"].AsString;
                DateTime ngaySinh = document["NgaySinh"].AsDateTime;
                string gioiTinh = document["GioiTinh"].AsString;
                string diaChi = document["DiaChi"].AsString;
                string sdt = document["Sdt"].AsString;
                string cmnd = document["Cmnd"].AsString;
                string email = document["Email"].AsString;

                dtb.Rows.Add(id, ten, ngaySinh, gioiTinh, diaChi, sdt, cmnd, email);
            }
            return dtb;
        }

        public bool ThemNhanVien(NhanVienDTO nhanVien)
        {
            //string[] param = { "@ID", "@Ten", "@IDChucDanh", "@NgaySinh", "@GioiTinh", "@DiaChi", "@SDT", "@CMND", "@Email" };
            //object[] values = { nhanVien.Id, nhanVien.Ten, nhanVien.IdChucDanh, nhanVien.NgaySinh, nhanVien.GioiTinh, nhanVien.DiaChi, nhanVien.Sdt, nhanVien.Cmnd, nhanVien.Email };
            //string query = "Insert Into NhanVien Values(@ID,@Ten,convert(date,@NgaySinh,105),@GioiTinh,@DiaChi,@SDT,@CMND,@Email,@IDChucDanh)";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public bool SuaNhanVien(NhanVienDTO nhanVien)
        {
            //string[] param = { "@ID", "@Ten", "@IDChucDanh", "@NgaySinh", "@GioiTinh", "@DiaChi", "@SDT", "@CMND", "@Email" };
            //object[] values = { nhanVien.Id, nhanVien.Ten, nhanVien.IdChucDanh, nhanVien.NgaySinh, nhanVien.GioiTinh, nhanVien.DiaChi, nhanVien.Sdt, nhanVien.Cmnd, nhanVien.Email };
            //string query = "Update NhanVien Set Ten=@Ten, IDChucDanh=@IDChucDanh, NgaySinh=convert(date,@NgaySinh,105), GioiTinh=@GioiTinh, DiaChi=@DiaChi, SDT=@SDT, CMND=@CMND, Email=@Email Where ID=@ID";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public bool XoaNhanVien(NhanVienDTO nhanVien)
        {
            //string[] param = { "@ID" };
            //object[] values = { nhanVien.Id };
            //string query = "Delete NhanVien Where ID=@ID";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public int IdChucDanh(string chucDanh)
        {
            //string query = "Select ID From ChucDanh Where Ten = N'" + chucDanh + "'";
            //DataTable dtb = DataProvider.Instance.getDS(query);
            //return int.Parse(dtb.Rows[0]["ID"].ToString());
            return 1;
        }
    }
}
