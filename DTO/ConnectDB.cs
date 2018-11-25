using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ConnectDB
    {
        private static ConnectDB instance;
        public static ConnectDB Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConnectDB();
                return instance;
            }
        }
        public string IpAddress;
        public string DatabaseName;
    }
}
