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
            List<BsonDocument> documents = DataProvider.Instance.getDocuments("ChucDanh");
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Id");
            dtb.Columns.Add("TenChucDanh");
            foreach (BsonDocument document in documents)
            {
                string id = document["Id"].AsString;
                string tenChucDanh = document["TenChucDanh"].AsString;

                dtb.Rows.Add(id, tenChucDanh);
            }
            return dtb;
        }

        public bool ThemChucDanh(ChucDanhDTO chucDanh)
        {
            //string[] param = { "@Ten" };
            //object[] values = { chucDanh.Ten };
            //string query = "Insert Into ChucDanh Values(@Ten)";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public bool SuaChucDanh(ChucDanhDTO chucDanh)
        {
            //string[] param = { "@ID", "@Ten" };
            //object[] values = { chucDanh.Id, chucDanh.Ten };
            //string query = "Update ChucDanh Set Ten=@Ten Where ID=@ID";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public bool XoaChucDanh(ChucDanhDTO chucDanh)
        {
            //string[] param = { "@ID" };
            //object[] values = { chucDanh.Id };
            //string query = "Delete ChucDanh Where ID=@ID";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
    }
}
