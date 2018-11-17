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
    public class DSPhongDAO
    {
        private static DSPhongDAO instance;

        public static DSPhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DSPhongDAO();
                return instance;
            }
        }

        private DSPhongDAO() { }

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
                string loaiPhong = document["LoaiPhong"].AsString;
                string trangThai = document["TrangThai"].AsString;

                dtb.Rows.Add(id, ten, loaiPhong, trangThai);
            }
            return dtb;
        }
    }
}