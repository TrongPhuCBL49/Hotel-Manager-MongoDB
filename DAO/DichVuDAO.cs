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

        private List<int> ids = new List<int>();

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
                ids.Add(int.Parse(id));
            }
            return dtb;
        }

        public bool ThemDichVu(DichVuDTO dichVu)
        {
            dichVu.Id = DataProvider.Instance.findMin(ids).ToString();
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"themDichVu('" + dichVu.Id + "','"
                                          + dichVu.Ten + "','"
                                          + dichVu.Gia + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool SuaDichVu(DichVuDTO dichVu)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"suaDichVu('" + dichVu.Id + "','"
                                         + dichVu.Ten + "','"
                                         + dichVu.Gia + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool XoaDichVu(DichVuDTO dichVu)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"xoaDichVu('" + dichVu.Id + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
    }
}
