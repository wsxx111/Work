using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FrameworkOfGoodMan.Tools.HelpNewer
{
    public class HelpNewer
    {
        #region 字段
        private static string conString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private static SqlConnection connection;
        #endregion

        #region  属性
        #region  属性Connection
        public static SqlConnection Connection
        {
            get
            {
                connection = new SqlConnection(conString);
                try
                {
                    //如果连接为空
                    if (connection == null)
                    {
                        connection.Open();
                    }
                    //如果连接状态为关闭
                    else if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    //如果连接状态损害
                    else if (connection.State == System.Data.ConnectionState.Broken)
                    {
                        connection.Close();
                        connection.Open();
                    }
                    return connection;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #endregion

        #region  方法
        #region 执行sql语句，不传递参数,返回受影响的行数
        /// <summary>
        /// 执行sql语句，返回受影响的行数
        /// </summary>
        /// <param name="safeSql">sql语句</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteCommand(string safeSql)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(safeSql, con);
            int result = -1;
            try
            {
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        #endregion

        #region  执行sql语句，同时传递参数，返回受影响的行数
        /// <summary>
        /// 执行sql语句，同时传递参数，返回受影响的行数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数列表</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(values);
            int result = -1;
            try
            {
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        #endregion

        #region 执行sql语句，不传递其他参数，返回第一行第一列的值，string类型
        /// <summary>
        /// 执行sql语句，不传递其他参数，返回第一行第一列的值
        /// </summary>
        /// <param name="safeSql">sql语句</param>
        /// <returns>string类型</returns>
        public static string ReturnStringScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            try
            {
                string result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region 执行sql语句，传递其他参数，返回第一行和第一列的值，string类型
        /// <summary>
        /// 执行sql语句，传递其他参数，返回第一行和第一列的值，string类型
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数列表</param>
        /// <returns>返回第一行和第一列的值</returns>
        public static string GetScalarByString(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(values);
            string result = null;
            try
            {
                con.Open();
                result = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        #endregion

        #region 执行sql语句，传递其他参数，返回第一行和第一列的值，int类型
        /// <summary>
        /// 执行sql语句，传递其他参数，返回第一行和第一列的值，int类型
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数列表</param>
        /// <returns>返回第一行和第一列的值</returns>
        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(values);
            int result = -1;
            try
            {
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        #endregion

        #region 执行sql语句，不传递其他参数，返回第一行第一列的值，int类型
        /// <summary>
        /// 执行sql语句，不传递其他参数，返回第一行第一列的值，int类型
        /// </summary>
        /// <param name="safeSql">sql语句</param>
        /// <returns>返回第一行第一列的值</returns>
        public static int GetScalar(string safeSql)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(safeSql, con);
            int result = -1;
            try
            {
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        #endregion

        #region  调用存储过程，传递参数，返回受影响的行数
        /// <summary>
        /// 调用存储过程，传递参数，返回受影响的行数
        /// </summary>
        /// <param name="StoredProcedure">存储过程名</param>
        /// <param name="values">参数列表</param>
        /// <returns>返回受影响的行数</returns>        
        public static int ExecuteCommandPro(string StoredProcedure, params SqlParameter[] values)
        {
            int result = -1;
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(conString);
            cmd.Connection = con;
            cmd.CommandText = StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            try
            {
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {             
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        #endregion

        #region 执行存储过程，传递参数，返回第一行第一列的值，int类型
        /// <summary>
        /// 执行存储过程，传递参数，返回第一行第一列的值，int类型
        /// </summary>
        /// <param name="StoredProcedure">存储过程名</param>
        /// <param name="values">参数列表</param>
        /// <returns>返回第一行第一列的值</returns>
        public static int GetScalar_pro(string StoredProcedure, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            int result = -1;
            try
            {
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        #endregion

        #region 执行存储过程，传递参数，返回第一行第一列的值，string类型
        public static string GetScalarString_pro(string StoredProcedure, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            string result = string.Empty;
            try
            {
                con.Open();
                result = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        #endregion

        #region 执行sql语句，不传其他参数，返回SqlDataReader对象
        /// <summary>
        /// 根据sql语句返回SqlDataReader对象
        /// </summary>
        /// <param name="safeSql">sql语句</param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string safeSql)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(safeSql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        #endregion

        #region 执行sql语句，传递其他参数，返回SqlDataReader对象
        /// <summary>
        /// 执行sql语句，传递其他参数，返回SqlDataReader对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数列表</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(values);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        #endregion

        #region 执行存储过程，传递参数，返回SqlDataReader对象
        /// <summary>
        /// 执行存储过程，传递参数，返回SqlDataReader对象
        /// </summary>
        /// <param name="Pro">存储过程名</param>
        /// <param name="values">参数</param>
        /// <returns>返回SqlDataReader对象</returns>
        public static SqlDataReader GetReaderPro(string Pro, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Pro;
            cmd.Connection = Connection;
            cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        #endregion

        #region 执行sql语句，不传递其他参数，返回DataTable对象
        /// <summary>
        /// 执行sql语句，不传递其他参数，返回DataTable对象
        /// </summary>
        /// <param name="safeSql">sql语句</param>
        /// <returns>返回DataTable对象</returns>
        public static DataTable GetDataTable(string safeSql)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        #endregion

        #region 执行sql语句，传递其他参数，返回DataTable对象
        /// <summary>
        /// 执行sql语句，传递其他参数，返回DataTable对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数列表</param>
        /// <returns>返回DataTable对象</returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        #endregion

        #region 执行存储过程，传递参数，返回DataTable对象
        /// <summary>
        /// 执行存储过程，传递参数，返回DataTable对象
        /// </summary>
        /// <param name="pro">存储过程名</param>
        /// <param name="values">参数</param>
        /// <returns>返回DataTable对象</returns>
        public static DataTable GetDataTable_Pro(string pro, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(pro, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
            {
                cmd.Parameters.AddRange(values);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        #endregion

        #region 执行存储过程，不传递参数，返回DataTable对象
        /// <summary>
        /// 执行存储过程，不传递参数，返回DataTable对象
        /// </summary>
        /// <param name="pro">存储过程名</param>
        /// <returns>返回DataTable对象</returns>
        public static DataTable GetDataTable_Pro(string pro)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(pro, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        #endregion

        #region 执行sql语句，传递3个参数，返回DataSet对象
        /// <summary>
        /// 执行sql语句，传递3个参数，返回DataSet对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="name">表名</param>
        /// <param name="values">参数</param>
        /// <returns>返回DataSet对象</returns>
        public static DataSet GetDataSet_Pro1(string sql, string name, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, name);
            return ds;
        }
        #endregion

        #region 执行sql语句，传递2个参数，返回DataSet对象
        /// <summary>
        /// 执行sql语句，传递2个参数，返回DataSet对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="name">表名</param>       
        /// <returns>返回DataSet对象</returns>
        public static DataSet GetDataSet_Pro2(string sql, string name)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, name);
            return ds;
        }
        #endregion

        #region  实例化一个用于调用存储过程的参数
        /// <summary>
        /// 实例化一个用于调用存储过程的参数
        /// </summary>
        /// <param name="ParamName">参数名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">传递方向</param>
        /// <param name="Value">值</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter Param;
            if (Size > 0)
            {
                Param = new SqlParameter(ParamName, DbType, Size);
            }

            else
            {
                Param = new SqlParameter(ParamName, DbType);
            }
            Param.Direction = Direction;
            if (Value != null)
                Param.Value = Value;
            return Param;
        }
        #endregion

        #region 实例化一个用于调用存储过程的输入参数，返回SqlParameter
        /// <summary>
        /// 实例化一个用于调用存储过程的输入参数，返回SqlParameter
        /// </summary>
        /// <param name="ParamName">参数名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">值</param>
        /// <returns></returns>
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
        #endregion

        #endregion
    }


    //从一个DataRow中，安全得到列colname中的值
    public class GetSafeData
    {
        #region 值为字符串类型
        /// <summary>
        /// 值为字符串类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.String.Empty</returns>
        public static string ValidateDataRowStr(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return row[colname].ToString();
            else
                return System.String.Empty;
        }
        #endregion

        #region 值为整数类型
        /// <summary>
        /// 值为整数类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.Int32.MinValue</returns>
        public static int ValidateDataRowInt(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToInt32(row[colname]);
            else
                return System.Int32.MinValue;
        }
        #endregion

        #region 值为字符串类型
        /// <summary>
        /// 值为布尔类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.Int32.MinValue</returns>
        public static bool ValidateDataRowBool(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToBoolean(row[colname]);
            else
                return false;
        }
        #endregion

        #region 值为浮点数类型
        /// <summary>
        /// 值为浮点数类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.Double.MinValue</returns>
        public static double ValidateDataRowDouble(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToDouble(row[colname]);
            else
                return System.Double.MinValue;
        }
        #endregion

        #region 值为时间类型
        /// <summary>
        /// 值为时间类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.DateTime.MinValue;</returns>
        public static DateTime ValidateDataRowDate(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToDateTime(row[colname]);
            else
                return System.DateTime.MinValue;
        }
        #endregion
    }

}
