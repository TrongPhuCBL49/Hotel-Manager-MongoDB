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

        private List<int> ids = new List<int>();

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
                ids.Add(int.Parse(id));
            }
            return dtb;
        }

        public bool ThemChucDanh(ChucDanhDTO chucDanh)
        {
            chucDanh.Id = DataProvider.Instance.findMin(ids).ToString();
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"themChucDanh('" + chucDanh.Id + "','"
                                            + chucDanh.Ten + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool SuaChucDanh(ChucDanhDTO chucDanh)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"suaChucDanh('" + chucDanh.Id + "','"
                                           + chucDanh.Ten + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool XoaChucDanh(ChucDanhDTO chucDanh)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"xoaChucDanh('" + chucDanh.Id + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
    }
}
