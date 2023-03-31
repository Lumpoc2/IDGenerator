using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace MISGroup_4.Modules
{
    public class Database
    {
        public string ConnString { get; set; } = "server=localhost;Database=mis;port=3306;username=root;password=mark_123";
        public MySqlConnection con;
        public MySqlCommand cmd;
    }
}
