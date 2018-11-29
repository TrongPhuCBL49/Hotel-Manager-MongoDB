using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using DTO;

namespace DAO
{
    public class DataProvider
    {

        public static string userName;
        public static string pass;
        public static string host;
        public static string databaseName;

        private MongoClient client;
        private IMongoDatabase database;

        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            } 
        }

        public IMongoDatabase Database { get => database; set => database = value; }
        public MongoClient Client { get => client; set => client = value; }

        private DataProvider()
        {
            connectDB();
        }

        //Kết nối
        public void connectDB()
        {
            try
            {
                MongoClient client = new MongoClient("mongodb://" + userName + ":" + pass + "@" + host + ":27017/admin");

                database = client.GetDatabase(databaseName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public List<BsonDocument> getDocuments(string nameColl)
        {
            try
            {
                IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(nameColl);
                List<BsonDocument> documents = collection.Find(new BsonDocument()).ToListAsync().Result;
                return documents;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }
        public int findMin(List<int> input)
        {
            if (input.Count < 1) return 0;
            if (input.Count == 1)
            {
                if (input[0] == 1) return 2;
                else return 1;
            }
            int[] t = new int[input.Count];
            for (int k = 0; k < input.Count; k++)
            {
                int i = input[k];
                if (i > 0) t[i - 1] = 1;
            }
            int gotcha = 1;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == 0)
                {
                    gotcha = i + 1;
                    break;
                }
            }
            return gotcha;
        }

    }
}
