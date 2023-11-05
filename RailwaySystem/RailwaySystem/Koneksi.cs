using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace RailwaySystem
{
    internal class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source = DESKTOP-E43IUIH\\SQLEXPRESS; initial catalog=RailwaySystem_db; integrated security=true";
            return Conn;
        }
    }
}
