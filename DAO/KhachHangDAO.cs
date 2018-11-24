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
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAO();
                return instance;
            }
        }

        private KhachHangDAO() { }

        public DataTable DSKhachHang()
        {
            List<BsonDocument> documents = DataProvider.Instance.getDocuments("KhachHang");
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Id");
            dtb.Columns.Add("Ten");
            dtb.Columns.Add("NgaySinh");
            dtb.Columns.Add("GioiTinh");
            dtb.Columns.Add("Email");
            dtb.Columns.Add("Sdt");
            dtb.Columns.Add("Cmnd");
            dtb.Columns.Add("QuocTich");
            foreach (BsonDocument document in documents)
            {
                string id = document["Id"].AsString;
                string ten = document["Ten"].AsString;
                DateTime ngaySinh = document["NgaySinh"].AsDateTime;
                string gioiTinh = document["GioiTinh"].AsString;
                string email = document["Email"].AsString;
                string sdt = document["Sdt"].AsString;
                string cmnd = document["Cmnd"].AsString;
                string quocTich = document["QuocTich"].AsString;

                dtb.Rows.Add(id, ten, ngaySinh, gioiTinh, email, sdt, cmnd, quocTich);
            }
            return dtb;
        }

        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"themKhachHang('" + khachHang.Id + "','"
                                             + khachHang.Ten + "', ISODate('"
                                             + khachHang.NgaySinh.ToString("yyyy-mm-dd") + "'),'"
                                             + khachHang.GioiTinh + "','"
                                             + khachHang.Sdt + "','"
                                             + khachHang.Cmnd + "','"
                                             + khachHang.QuocTich + "','"
                                             + khachHang.Email + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool SuaKhachHang(KhachHangDTO khachHang)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"suaKhachHang('" + khachHang.Id + "','"
                                             + khachHang.Ten + "', ISODate('"
                                             + khachHang.NgaySinh.ToString("yyyy-mm-dd") + "'),'"
                                             + khachHang.GioiTinh + "','"
                                             + khachHang.Sdt + "','"
                                             + khachHang.Cmnd + "','"
                                             + khachHang.QuocTich + "','"
                                             + khachHang.Email + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool XoaKhachHang(KhachHangDTO khachHang)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"xoaKhachHang('" + khachHang.Id + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
    }
}
