using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace WK.Data
{
    public class DBUniversalHelper
    {
        private static DbProviderFactory _factory;//抽象数据工厂

        private static string _rdbstablepre;//关系数据库对象前缀

        private static string _connectionstring;//关系数据库连接字符串

        /// <summary>
        /// 关系数据库对象前缀
        /// </summary>
        public static string RDBSTablePre
        {
            get { return _rdbstablepre; }
        }

        /// <summary>
        /// 关系数据库连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get { return _connectionstring; }
        }

        static DBUniversalHelper()
        {
            //  可设置其他为 数据库  如Oracle  _factory=System.Data.OracleClient.Instance;
            //这个初始化可以在上面声明时直接赋值
            //设置数据工厂
             _factory = System.Data.SqlClient.SqlClientFactory.Instance;           
            //设置关系数据库对象前缀
              _rdbstablepre = "";
            //设置关系数据库连接字符串
              _connectionstring = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
          
        }

        #region ExecuteNonQuery

        public static int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(CommandType.Text, cmdText, null);
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(cmdType, cmdText, null);
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {

            DbCommand cmd = _factory.CreateCommand();

            using (DbConnection conn = _factory.CreateConnection())
            {
                conn.ConnectionString = ConnectionString;
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                int val = cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                return val;
            }
        }



        public static int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(trans, cmdType, cmdText, null);
        }

        public static int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {

            DbCommand cmd = _factory.CreateCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);

            int val = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region ExecuteReader

        public static DbDataReader ExecuteReader(CommandType cmdType, string cmdText)
        {
            return ExecuteReader(cmdType, cmdText, null);
        }

        public static DbDataReader ExecuteReader(CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {

            DbCommand cmd = _factory.CreateCommand();
            DbConnection conn = _factory.CreateConnection();
            conn.ConnectionString = ConnectionString;

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
#if DEBUG
                DateTime startTime = DateTime.Now;
#endif
                DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public static DbDataReader ExecuteReader(DbTransaction trans, CommandType cmdType, string cmdText)
        {
            return ExecuteReader(trans, cmdType, cmdText, null);
        }

        public static DbDataReader ExecuteReader(DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {

            DbCommand cmd = _factory.CreateCommand();

            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);

            DbDataReader rdr = cmd.ExecuteReader();

            cmd.Parameters.Clear();
            return rdr;

        }

        #endregion

        #region ExecuteScalar

        public static object ExecuteScalar(CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(cmdType, cmdText, null);
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {


            DbCommand cmd = _factory.CreateCommand();

            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
#if DEBUG
                DateTime startTime = DateTime.Now;
#endif
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static object ExecuteScalar(DbTransaction trans, CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(trans, cmdType, cmdText, null);
        }

        public static object ExecuteScalar(DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {

            DbCommand cmd = _factory.CreateCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
#if DEBUG
            DateTime startTime = DateTime.Now;
#endif
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region ExecuteDataset

        public static DataSet ExecuteDataset(CommandType cmdType, string cmdText)
        {
            return ExecuteDataset(cmdType, cmdText, null);
        }

        public static DataSet ExecuteDataset(CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {

            DbCommand cmd = _factory.CreateCommand();
            DbConnection conn = _factory.CreateConnection();
            conn.ConnectionString = ConnectionString;
            DbDataAdapter adapter = _factory.CreateDataAdapter();

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {
                adapter.Dispose();
                conn.Close();
            }
        }

        public static DataSet ExecuteDataset(DbTransaction trans, CommandType cmdType, string cmdText)
        {
            return ExecuteDataset(trans, cmdType, cmdText, null);
        }

        public static DataSet ExecuteDataset(DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {

            DbCommand cmd = _factory.CreateCommand();
            DbDataAdapter adapter = _factory.CreateDataAdapter();

            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();

#if DEBUG
            DateTime startTime = DateTime.Now;
#endif
            adapter.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }

        #endregion

        private static void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction trans, CommandType cmdType, string cmdText, DbParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (DbParameter parm in cmdParms)
                {
                    if (parm != null)
                    {
                        if ((parm.Direction == ParameterDirection.InputOutput || parm.Direction == ParameterDirection.Input) &&
                            (parm.Value == null))
                        {
                            parm.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parm);
                    }
                }
            }
        }
   
    }
}
