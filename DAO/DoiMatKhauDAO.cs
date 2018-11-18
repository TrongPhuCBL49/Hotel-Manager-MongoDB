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
    public class DoiMatKhauDAO
    {
        private static DoiMatKhauDAO instance;
        public static DoiMatKhauDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DoiMatKhauDAO();
                return instance;
            }
        }
        private DoiMatKhauDAO() { }

        public bool KiemTraPass(UserDTO user)
        {
            var cmd = new JsonCommand<BsonDocument>("{ eval: \"kiemTraUser('" + user.IdNhanVien + "','" + user.Pass + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }

        public bool DoiMatKhau(UserDTO user)
        {
            var cmd = new JsonCommand<BsonDocument>("{ eval: \"doiMatKhau('" + user.IdNhanVien + "','" + user.Pass + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
    }
}
