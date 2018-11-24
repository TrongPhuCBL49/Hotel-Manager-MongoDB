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
            return PhongDAO.Instance.DSPhong(); 
        }
    }
}