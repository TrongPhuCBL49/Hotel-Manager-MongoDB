using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

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
            string query = "Select * From KhachHang";
            return DataProvider.Instance.getDS(query);
        }

        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            string[] param = { "@ID", "@Ten", "@NgaySinh", "@GioiTinh", "@Email", "@SDT", "@CMND", "@QuocTich" };
            object[] values = { khachHang.Id, khachHang.Ten, khachHang.NgaySinh, khachHang.GioiTinh, khachHang.Email, khachHang.Sdt, khachHang.Cmnd, khachHang.QuocTich };
            string query = "Insert Into KhachHang Values(@ID,@Ten,convert(date,@NgaySinh,105),@GioiTinh,@Email,@SDT,@CMND,@QuocTich)";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
        public bool SuaKhachHang(KhachHangDTO khachHang)
        {
            string[] param = { "@ID", "@Ten", "@NgaySinh", "@GioiTinh", "@Email", "@SDT", "@CMND", "@QuocTich" };
            object[] values = { khachHang.Id, khachHang.Ten, khachHang.NgaySinh, khachHang.GioiTinh, khachHang.Email, khachHang.Sdt, khachHang.Cmnd, khachHang.QuocTich };
            string query = "Update KhachHang Set Ten=@Ten, NgaySinh=convert(date,@NgaySinh,105), GioiTinh=@GioiTinh, QuocTich=@QuocTich, SDT=@SDT, CMND=@CMND, Email=@Email Where ID=@ID";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
        public bool XoaKhachHang(KhachHangDTO khachHang)
        {
            string[] param = { "@ID" };
            object[] values = { khachHang.Id };
            string query = "Delete KhachHang Where ID=@ID";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
    }
}
