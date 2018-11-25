using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DAO
{
    public class DatPhongDAO
    {
        private static DatPhongDAO instance;

        public static DatPhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DatPhongDAO();
                return instance;
            }
        }

        private DatPhongDAO() { }
        public DataRow ThongTinKhachHang(string TenKhachHang)
        {
            DataTable dtb = KhachHangDAO.Instance.DSKhachHang();
            DataRow row = dtb.AsEnumerable().SingleOrDefault(r => r.Field<string>("Ten") == TenKhachHang);
            return row;
        }
        public bool ThemBangThuePhong(BangThuePhongDTO bangThuePhong)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"themThuePhongTG('" + bangThuePhong.Id + "','"
                                               + bangThuePhong.IdPhong + "','"
                                               + bangThuePhong.IdNhanVien + "','"
                                               + bangThuePhong.IdKhachHang + "', ISODate('"
                                               + bangThuePhong.CheckIn.ToString("yyyy-mm-dd") + "'), ISODate('"
                                               + bangThuePhong.CheckOut.ToString("yyyy-mm-dd") + "'),'"
                                               + bangThuePhong.TienDatCoc + "','"
                                               + bangThuePhong.TrangThai + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public string IdPhong(string tenPhong)
        {
            DataTable dtb = PhongDAO.Instance.DSPhong();
            DataRow row = dtb.AsEnumerable().SingleOrDefault(r => r.Field<string>("Ten") == tenPhong);
            return row["Id"].ToString();
        }
        public string TenNhanVien(string idNhanVien)
        {
            DataTable dtb = NhanVienDAO.Instance.DSNhanVien();
            DataRow row = dtb.AsEnumerable().SingleOrDefault(r => r.Field<string>("Id") == idNhanVien);
            return row["Ten"].ToString();
        }
    }
}
