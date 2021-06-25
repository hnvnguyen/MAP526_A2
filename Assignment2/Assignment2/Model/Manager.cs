using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.Model
{
    public class Manager
    {
        public NetworkingManager networkingManager = new NetworkingManager();
        public DBManager dbManager = new DBManager();

        public Manager() {}
    }
}
