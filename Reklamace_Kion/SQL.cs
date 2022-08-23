using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Reklamace_Kion
{
    public class SQL
    {
        string conString = @"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace";
        public SqlConnection con;

        public void OpenConection()
        {
            con = new SqlConnection(conString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }

        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public DataTable DataTable(string Query_)
        {
            SqlDataAdapter da = new SqlDataAdapter(Query_, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int CountCols(string TableName)
        {
            SqlCommand cmd = new SqlCommand("select count(*) as Number from information_schema.columns where table_name='" + TableName + "'", con);
            return (int)cmd.ExecuteScalar();
        }
    }
}
