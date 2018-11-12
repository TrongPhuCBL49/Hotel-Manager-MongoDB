using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class KhachHangBUS
    {
        private static KhachHangBUS instance;

        public static KhachHangBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangBUS();
                return instance;
            }
        }

        private KhachHangBUS() { }

        public DataTable DSKhachHang()
        {
            return KhachHangDAO.Instance.DSKhachHang();
        }

        public bool ThemKhachHang(string Id, string TenKhachHang, DateTime NgaySinh, string GioiTinh, string QuocTich, string SDT, string CMND, string Email)
        {
            KhachHangDTO KhachHang = new KhachHangDTO();
            try
            {
                KhachHang.Id = Id;
                KhachHang.Ten = TenKhachHang;
                KhachHang.NgaySinh = NgaySinh;
                KhachHang.GioiTinh = GioiTinh;
                KhachHang.QuocTich = QuocTich;
                KhachHang.Sdt = SDT;
                KhachHang.Cmnd = CMND;
                KhachHang.Email = Email;
            }
            catch (Exception)
            {
                return false;
            }
            return KhachHangDAO.Instance.ThemKhachHang(KhachHang);
        }
        public bool SuaKhachHang(string Id, string TenKhachHang, DateTime NgaySinh, string GioiTinh, string QuocTich, string SDT, string CMND, string Email)
        {
            KhachHangDTO KhachHang = new KhachHangDTO();
            try
            {
                KhachHang.Id = Id;
                KhachHang.Ten = TenKhachHang;
                KhachHang.NgaySinh = NgaySinh;
                KhachHang.GioiTinh = GioiTinh;
                KhachHang.QuocTich = QuocTich;
                KhachHang.Sdt = SDT;
                KhachHang.Cmnd = CMND;
                KhachHang.Email = Email;
            }
            catch (Exception)
            {
                return false;
            }
            return KhachHangDAO.Instance.SuaKhachHang(KhachHang);
        }
        public bool XoaKhachHang(string Id)
        {
            KhachHangDTO KhachHang = new KhachHangDTO();
            KhachHang.Id = Id;
            return KhachHangDAO.Instance.XoaKhachHang(KhachHang);
        }

    }
}
