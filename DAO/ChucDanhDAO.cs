using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class ChucDanhDAO
    {
        private static ChucDanhDAO instance;

        public static ChucDanhDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChucDanhDAO();
                return instance;
            }
        }

        private ChucDanhDAO() { }

        public DataTable DSChucDanh()
        {
            string query = "Select * From ChucDanh";
            return DataProvider.Instance.getDS(query);
        }

        public bool ThemChucDanh(ChucDanhDTO chucDanh)
        {
            string[] param = { "@Ten" };
            object[] values = { chucDanh.Ten };
            string query = "Insert Into ChucDanh Values(@Ten)";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
        public bool SuaChucDanh(ChucDanhDTO chucDanh)
        {
            string[] param = { "@ID", "@Ten" };
            object[] values = { chucDanh.Id, chucDanh.Ten };
            string query = "Update ChucDanh Set Ten=@Ten Where ID=@ID";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
        public bool XoaChucDanh(ChucDanhDTO chucDanh)
        {
            string[] param = { "@ID" };
            object[] values = { chucDanh.Id };
            string query = "Delete ChucDanh Where ID=@ID";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
    }
}
