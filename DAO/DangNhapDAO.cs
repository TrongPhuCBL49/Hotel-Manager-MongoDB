using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DAO
{
    public class DangNhapDAO
    {
        private static DangNhapDAO instance;
        public static DangNhapDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DangNhapDAO();
                return instance;
            }
        }
        private DangNhapDAO() { }

        public bool KiemTraUser(UserDTO userDTO)
        {
            //IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Users");
            //var el = BsonDocument.Parse("{$and:[{\"IdNhanVien\":\"" + userDTO.IdNhanVien + "\"}, {\"Password\":\"" + userDTO.Pass + "\"}]}");
            //var doc = new QueryDocument(el);
            //int result = (int)collection.Find(doc).Count();
            //return (result > 0);

            var cmd = new JsonCommand<BsonDocument>("{ eval: \"kiemTraUser('" + userDTO.IdNhanVien + "','" + userDTO.Pass + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();





            //var query_id = Query.EQ("_id", ObjectId.Parse("50ed4e7d5baffd13a44d0153"));
            //var entity = collection.Find(query_id);
            //return entity.ToString();
            //string query = "Select * From Users Where IDNhanVien = '" + userDTO.IdNhanVien + "' and Pass = '" + userDTO.Pass + "'";
            //DataTable dtb = DataProvider.Instance.getDS(query);
            //return (dtb.Rows.Count > 0);
        }

        public int IdChucDanh(string idNhanVien)
        {
            //string query = "Select IDChucDanh From Users Where IDNhanVien = '" + idNhanVien + "'";
            //DataTable dtb = DataProvider.Instance.getDS(query);
            //return int.Parse(dtb.Rows[0]["IDChucDanh"].ToString());
            return 1;
        }
    }
}
