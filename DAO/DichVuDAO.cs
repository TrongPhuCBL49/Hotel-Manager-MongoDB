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
            List<BsonDocument> documents = DataProvider.Instance.getDocuments("DichVu");
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Id");
            dtb.Columns.Add("Ten");
            dtb.Columns.Add("Gia");
            foreach (BsonDocument document in documents)
            {
                string id = document["Id"].AsString;
                string ten = document["Ten"].AsString;
                string gia = document["Gia"].AsString;

                dtb.Rows.Add(id, ten, gia);
            }
            return dtb;
        }

        public bool ThemDichVu(DichVuDTO dichVu)
        {
            //string[] param = { "@Ten", "@Gia" };
            //object[] values = { dichVu.Ten, dichVu.Gia };
            //string query = "Insert Into DichVu Values(@Ten,@Gia)";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public bool SuaDichVu(DichVuDTO dichVu)
        {
            //string[] param = { "@ID", "@Ten", "@Gia" };
            //object[] values = { dichVu.Id, dichVu.Ten, dichVu.Gia };
            //string query = "Update DichVu Set Ten=@Ten, Gia=@Gia Where ID=@ID";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public bool XoaDichVu(DichVuDTO dichVu)
        {
            //string[] param = { "@ID" };
            //object[] values = { dichVu.Id };
            //string query = "Delete DichVu Where ID=@ID";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
    }
}
