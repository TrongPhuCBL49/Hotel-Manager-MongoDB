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
    public class PhongDAO
    {
        private static PhongDAO instance;

        public static PhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhongDAO();
                return instance;
            }
        }

        private PhongDAO() { }

        public DataTable DSPhong()
        {
            List<BsonDocument> documents = DataProvider.Instance.getDocuments("Phong");
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Id");
            dtb.Columns.Add("Ten");
            dtb.Columns.Add("LoaiPhong");
            dtb.Columns.Add("TrangThai");
            foreach (BsonDocument document in documents)
            {
                string id = document["Id"].AsString;
                string ten = document["Ten"].AsString;
                string loaiPhong = getLoaiPhong(ten);
                string trangThai = document["TrangThai"].AsString;
                dtb.Rows.Add(id, ten, loaiPhong, trangThai);
            }
            return dtb;
        }
        public bool ThemPhong(PhongDTO phong)
        {
            string id = getIdLoaiPhong(phong.LoaiPhong);
            phong.LoaiPhong = id.Remove(id.Length - 2).Remove(0, 10);
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"themPhong('" + phong.Id + "','"
                                         + phong.Ten + "', ObjectId('"
                                         + phong.LoaiPhong + "'),'"
                                         + phong.TrangThai + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool SuaPhong(PhongDTO phong)
        {
            string id = getIdLoaiPhong(phong.LoaiPhong);
            phong.LoaiPhong = id.Remove(id.Length - 2).Remove(0, 10); 
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"suaPhong('" + phong.Id + "','"
                                        + phong.Ten + "', ObjectId('"
                                        + phong.LoaiPhong + "'),'"
                                        + phong.TrangThai + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool XoaPhong(PhongDTO phong)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"xoaPhong('" + phong.Id + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public string getLoaiPhong(string tenPhong)
        {
            var cmd = new JsonCommand<BsonDocument>("{ eval: \"loaiPhong('" + tenPhong + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToString();
        }

        public string getIdLoaiPhong(string tenLoaiPhong)
        {
            var cmd = new JsonCommand<BsonDocument>("{ eval: \"idLoaiPhong('" + tenLoaiPhong + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToString();
        }

    }
}
