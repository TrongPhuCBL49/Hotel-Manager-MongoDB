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
    public class NhanVienBUS
    {
        private static NhanVienBUS instance;

        public static NhanVienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienBUS();
                return instance;
            }
        }

        private NhanVienBUS() { }

        public DataTable DSNhanVien()
        {
            return NhanVienDAO.Instance.DSNhanVien();
        }

        public bool ThemNhanVien(string Id, string TenNhanVien, DateTime NgaySinh, string GioiTinh, string DiaChi, string SDT, string CMND, string Email)
        {
            NhanVienDTO NhanVien = new NhanVienDTO();
            try
            {
                NhanVien.Id = Id;
                NhanVien.Ten = TenNhanVien;
                NhanVien.NgaySinh = NgaySinh;
                NhanVien.GioiTinh = GioiTinh;
                NhanVien.DiaChi = DiaChi;
                NhanVien.Sdt = SDT;
                NhanVien.Cmnd = CMND;
                NhanVien.Email = Email;
            }
            catch (Exception)
            {
                return false;
            }
            return NhanVienDAO.Instance.ThemNhanVien(NhanVien);
        }
        public bool SuaNhanVien(string Id, string TenNhanVien, DateTime NgaySinh, string GioiTinh, string DiaChi, string SDT, string CMND, string Email)
        {
            NhanVienDTO NhanVien = new NhanVienDTO();
            try
            {
                NhanVien.Id = Id;
                NhanVien.Ten = TenNhanVien;
                NhanVien.NgaySinh = NgaySinh;
                NhanVien.GioiTinh = GioiTinh;
                NhanVien.DiaChi = DiaChi;
                NhanVien.Sdt = SDT;
                NhanVien.Cmnd = CMND;
                NhanVien.Email = Email;
            }
            catch (Exception)
            {
                return false;
            }
            return NhanVienDAO.Instance.SuaNhanVien(NhanVien);
        }
        public bool XoaNhanVien(string Id)
        {
            NhanVienDTO NhanVien = new NhanVienDTO();
            NhanVien.Id = Id;
            return NhanVienDAO.Instance.XoaNhanVien(NhanVien);
        }

    }
}
