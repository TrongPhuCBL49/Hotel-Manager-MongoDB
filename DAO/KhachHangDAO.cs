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
            //string[] param = { "@ID", "@Ten", "@NgaySinh", "@GioiTinh", "@Email", "@SDT", "@CMND", "@QuocTich" };
            //object[] values = { khachHang.Id, khachHang.Ten, khachHang.NgaySinh, khachHang.GioiTinh, khachHang.Email, khachHang.Sdt, khachHang.Cmnd, khachHang.QuocTich };
            //string query = "Insert Into KhachHang Values(@ID,@Ten,convert(date,@NgaySinh,105),@GioiTinh,@Email,@SDT,@CMND,@QuocTich)";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public bool SuaKhachHang(KhachHangDTO khachHang)
        {
            //string[] param = { "@ID", "@Ten", "@NgaySinh", "@GioiTinh", "@Email", "@SDT", "@CMND", "@QuocTich" };
            //object[] values = { khachHang.Id, khachHang.Ten, khachHang.NgaySinh, khachHang.GioiTinh, khachHang.Email, khachHang.Sdt, khachHang.Cmnd, khachHang.QuocTich };
            //string query = "Update KhachHang Set Ten=@Ten, NgaySinh=convert(date,@NgaySinh,105), GioiTinh=@GioiTinh, QuocTich=@QuocTich, SDT=@SDT, CMND=@CMND, Email=@Email Where ID=@ID";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public bool XoaKhachHang(KhachHangDTO khachHang)
        {
            //string[] param = { "@ID" };
            //object[] values = { khachHang.Id };
            //string query = "Delete KhachHang Where ID=@ID";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
    }
}
