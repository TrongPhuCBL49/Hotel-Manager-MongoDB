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
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"themNhanVien('" + nhanVien.Id + "','"
                                            + nhanVien.Ten + "', ISODate('"
                                            + nhanVien.NgaySinh.ToString("yyyy-mm-dd") + "'),'"
                                            + nhanVien.GioiTinh + "','"
                                            + nhanVien.DiaChi + "','"
                                            + nhanVien.Sdt + "','"
                                            + nhanVien.Cmnd + "','"
                                            + nhanVien.Email + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool SuaNhanVien(NhanVienDTO nhanVien)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"suaNhanVien('" + nhanVien.Id + "','"
                                           + nhanVien.Ten + "', ISODate('"
                                           + nhanVien.NgaySinh.ToString("yyyy-mm-dd") + "'),'"
                                           + nhanVien.GioiTinh + "','"
                                           + nhanVien.DiaChi + "','"
                                           + nhanVien.Sdt + "','"
                                           + nhanVien.Cmnd + "','"
                                           + nhanVien.Email + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool XoaNhanVien(NhanVienDTO nhanVien)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"xoaNhanVien('" + nhanVien.Id + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
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
