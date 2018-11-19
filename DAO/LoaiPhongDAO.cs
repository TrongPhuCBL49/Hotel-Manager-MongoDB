using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DAO
{
    public class LoaiPhongDAO
    {
        private static LoaiPhongDAO instance;

        public static LoaiPhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiPhongDAO();
                return instance;
            }
        }

        private LoaiPhongDAO() { }

        private List<int> ids = new List<int>();

        public DataTable DSLoaiPhong()
        {
            List<BsonDocument> documents = DataProvider.Instance.getDocuments("LoaiPhong");
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Id");
            dtb.Columns.Add("Ten");
            dtb.Columns.Add("Gia");
            dtb.Columns.Add("TienPhuThu");
            dtb.Columns.Add("SoGiuong");
            foreach (BsonDocument document in documents)
            {
                string id = document["Id"].AsString;
                string ten = document["Ten"].AsString;
                string gia = document["Gia"].AsString;
                string tienPhuThu = document["TienPhuThu"].AsString;
                string soGiuong = document["SoGiuong"].AsString;
                dtb.Rows.Add(id, ten, gia, tienPhuThu, soGiuong);
                ids.Add(int.Parse(id));
            }
            
            return dtb;
        }

        public bool ThemLoaiPhong(LoaiPhongDTO loaiPhong)
        {
            loaiPhong.Id = DataProvider.Instance.findMin(ids).ToString();
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"themLoaiPhong('" + loaiPhong.Id + "','" 
                                             + loaiPhong.Ten + "','"
                                             + loaiPhong.Gia + "','"
                                             + loaiPhong.SoGiuong + "','"
                                             + loaiPhong.TienPhuThu + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool SuaLoaiPhong(LoaiPhongDTO loaiPhong)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"suaLoaiPhong('" + loaiPhong.Id + "','"
                                             + loaiPhong.Ten + "','"
                                             + loaiPhong.Gia + "','"
                                             + loaiPhong.SoGiuong + "','"
                                             + loaiPhong.TienPhuThu + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
        public bool XoaLoaiPhong(LoaiPhongDTO loaiPhong)
        {
            var cmd = new JsonCommand<BsonDocument>
                ("{ eval: \"xoaLoaiPhong('" + loaiPhong.Id + "')\" }");
            var result = DataProvider.Instance.Database.RunCommand(cmd);
            return result["retval"].ToBoolean();
        }
    }
}
