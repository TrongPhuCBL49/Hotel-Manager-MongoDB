using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO instance;

        public static DichVuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DichVuDAO();
                return instance;
            }
        }

        private DichVuDAO() { }

        public DataTable DSDichVu()
        {
            string query = "Select * From DichVu";
            return DataProvider.Instance.getDS(query);
        }

        public bool ThemDichVu(DichVuDTO dichVu)
        {
            string[] param = { "@Ten", "@Gia" };
            object[] values = { dichVu.Ten, dichVu.Gia };
            string query = "Insert Into DichVu Values(@Ten,@Gia)";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
        public bool SuaDichVu(DichVuDTO dichVu)
        {
            string[] param = { "@ID", "@Ten", "@Gia" };
            object[] values = { dichVu.Id, dichVu.Ten, dichVu.Gia };
            string query = "Update DichVu Set Ten=@Ten, Gia=@Gia Where ID=@ID";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
        public bool XoaDichVu(DichVuDTO dichVu)
        {
            string[] param = { "@ID" };
            object[] values = { dichVu.Id };
            string query = "Delete DichVu Where ID=@ID";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
    }
}
