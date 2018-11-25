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
            var cmd = new JsonCommand<BsonDocument>("{ eval: \"kiemTraUser('" + userDTO.IdNhanVien + "','" + userDTO.Pass + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
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
