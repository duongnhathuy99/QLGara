using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class Connect
    {
        private static string s = "Data Source=huy;Initial Catalog=QLGara;Integrated Security=True";
        private SqlConnection connect;
        public static DataTable ExcecuteQuery(string sql)
        {
            try
            {
                SqlConnection cn = new SqlConnection(s);
                SqlCommand cmd = new SqlCommand(sql,cn);               
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable kq = new DataTable();
                dt.Fill(kq);
                cn.Close();

                return kq;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                DataTable dt = new DataTable();
                return dt;
            }
        }
        public static bool ExcuteNonQuery(string sql)
        {
            try
            {
                SqlConnection cn = new SqlConnection(s);
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            { return false; }

        }
    }
}
