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
                string loaiPhong = document["LoaiPhong"].AsString;
                string trangThai = document["TrangThai"].AsString;

                dtb.Rows.Add(id, ten, loaiPhong, trangThai);
            }
            return dtb;
        }

        public bool ThemPhong(PhongDTO phong)
        {
            //string[] param = { "@ID", "@Ten", "@IDLoai", "@IdTrangThai" };
            //object[] values = { phong.Id, phong.Ten, phong.IdLoai, phong.IdTrangThai };
            //string query = "Insert Into Phong Values(@ID,@Ten,@IDLoai,@IDTrangThai)";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public bool SuaPhong(PhongDTO phong)
        {
            //string[] param = { "@ID", "@Ten", "@IDLoai", "@IDTrangThai" };
            //object[] values = { phong.Id, phong.Ten, phong.IdLoai, phong.IdTrangThai };
            //string query = "Update Phong Set Ten=@Ten, IDLoai=@IDLoai, IDTrangThai=@IDTrangThai Where ID=@ID";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public bool XoaPhong(PhongDTO phong)
        {
            //string[] param = { "@ID" };
            //object[] values = { phong.Id };
            //string query = "Delete Phong Where ID=@ID";
            //return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
            return true;
        }
        public int IdLoaiPhong(string loaiPhong)
        {
            //string query = "Select ID From LoaiPhong Where Ten = N'" + loaiPhong + "'";
            //DataTable dtb = DataProvider.Instance.getDS(query);
            //return int.Parse(dtb.Rows[0]["ID"].ToString());
            return 1;
        }
        public int IdTrangThai(string trangThai)
        {
            //string query = "Select ID From TrangThai Where Ten = N'" + trangThai + "'";
            //DataTable dtb = DataProvider.Instance.getDS(query);
            //return int.Parse(dtb.Rows[0]["ID"].ToString());
            return 1;
        }

    }
}
