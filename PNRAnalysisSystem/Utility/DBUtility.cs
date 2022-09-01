using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Utility
{
    public class DBUtility
    {
        public string ConnectionString { get; set; }
        public DBUtility()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true);

            var config = builder.Build();
            ConnectionString = config["DefaultConnectionString"];
        }

        /// <summary>
        /// Exec script
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet Query(string sql)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                string ex = e.Message;
            }

            return ds;
        }
        public bool ExecScript(string sql)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                   return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Exec With Dictionary
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool ExecProcWithObject(string sp, Dictionary<string, object> param)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(sp, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var item in param)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public DataSet QueryProcWithObject(string sp, Dictionary<string, object> param)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in param)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
            }

            return ds;
        }

        /// <summary>
        /// Exec With Entity
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool ExecProc<T>(string sp, T t)
        {
            var paramObject = ReflectionEntity(t);

            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(sp, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var item in paramObject)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public DataSet QueryProc<T>(string sp, T t)
        {
            var paramObject = ReflectionEntity(t);

            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in paramObject)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
            }

            return ds;
        }

        /// <summary>
        /// Reflection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        private Dictionary<string,object> ReflectionEntity<T>(T t)
        {        
            var dic = t.GetType()
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .ToDictionary(prop => prop.Name, prop => prop.GetValue(t, null));

            return dic;
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
