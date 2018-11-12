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
    public class ChucDanhBUS
    {
        private static ChucDanhBUS instance;

        public static ChucDanhBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChucDanhBUS();
                return instance;
            }
        }

        private ChucDanhBUS() { }

        public DataTable DSChucDanh()
        {
            return ChucDanhDAO.Instance.DSChucDanh();
        }

        public bool ThemChucDanh(string TenChucDanh)
        {
            ChucDanhDTO ChucDanh = new ChucDanhDTO();
            try
            {
                ChucDanh.Ten = TenChucDanh;
            }
            catch (Exception)
            {
                return false;
            }
            return ChucDanhDAO.Instance.ThemChucDanh(ChucDanh);
        }
        public bool SuaChucDanh(string Id, string TenChucDanh)
        {
            ChucDanhDTO ChucDanh = new ChucDanhDTO();
            try
            {
                ChucDanh.Id = int.Parse(Id);
                ChucDanh.Ten = TenChucDanh;
            }
            catch (Exception)
            {
                return false;
            }
            return ChucDanhDAO.Instance.SuaChucDanh(ChucDanh);
        }
        public bool XoaChucDanh(string Id)
        {
            ChucDanhDTO ChucDanh = new ChucDanhDTO();
            ChucDanh.Id = int.Parse(Id);
            return ChucDanhDAO.Instance.XoaChucDanh(ChucDanh);
        }

    }
}
