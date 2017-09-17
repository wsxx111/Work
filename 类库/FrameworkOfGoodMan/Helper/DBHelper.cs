using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FrameworkOfGoodMan.Tools.Helper
{
    /// <summary>
    /// 访问数据库方法
    /// </summary>
    public class DBHelper
    {
        private static DbProviderFactory _factory;//抽象数据工厂      

        private static string _connectionstring;//关系数据库连接字符串

        /// <summary>
        /// 关系数据库连接字符串
        /// </summary>
        public static DbProviderFactory Factory
        {
            set { _factory = value; }
            get { return _factory; }
        }

        /// <summary>
        /// 关系数据库连接字符串
        /// </summary>
        public static string ConnectionString
        {
            set { _connectionstring = value; }
            get { return _connectionstring; }
        }       


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


        #region ExecuteNonQuery

        public static int ExecuteNonQuery(string cmdText, CommandType cmdType = CommandType.Text)
        {
            return ExecuteNonQuery(cmdText,cmdType,null);
        }

        public static int ExecuteNonQuery(string cmdText,CommandType cmdType, params DbParameter[] commandParameters)
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



        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, DbTransaction trans)
        {
            return ExecuteNonQuery(cmdType, cmdText, trans, null);
        }


        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, DbTransaction trans, params DbParameter[] commandParameters)
        {

            DbCommand cmd = _factory.CreateCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);

            int val = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region ExecuteReader

        public static DbDataReader ExecuteReader(string cmdText,CommandType cmdType)
        {
            return ExecuteReader(cmdText,cmdType,null);
        }

        public static DbDataReader ExecuteReader(string cmdText, CommandType cmdType, params DbParameter[] commandParameters)
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

        public static DbDataReader ExecuteReader(CommandType cmdType, string cmdText, DbTransaction trans)
        {
            return ExecuteReader(cmdType, cmdText, trans, null);
        }

        public static DbDataReader ExecuteReader(CommandType cmdType, string cmdText, DbTransaction trans, params DbParameter[] commandParameters)
        {

            DbCommand cmd = _factory.CreateCommand();

            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);

            DbDataReader rdr = cmd.ExecuteReader();

            cmd.Parameters.Clear();
            return rdr;

        }

        #endregion


        #region ExecuteScalar

        public static object ExecuteScalar(string cmdText,CommandType cmdType)
        {
            return ExecuteScalar(cmdText, cmdType,null);
        }

        public static object ExecuteScalar(string cmdText, CommandType cmdType, params DbParameter[] commandParameters)
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

        public static object ExecuteScalar(CommandType cmdType, string cmdText,DbTransaction trans)
        {
            return ExecuteScalar(cmdType, cmdText, trans, null);
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText, DbTransaction trans, params DbParameter[] commandParameters)
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

        public static DataSet ExecuteDataset(string cmdText,CommandType cmdType)
        {
            return ExecuteDataset(cmdText, cmdType,null);
        }

        public static DataSet ExecuteDataset(string cmdText, CommandType cmdType, params DbParameter[] commandParameters)
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

        public static DataSet ExecuteDataset(CommandType cmdType, string cmdText, DbTransaction trans = null)
        {
            return ExecuteDataset(cmdType, cmdText, trans, null);
        }

        public static DataSet ExecuteDataset(CommandType cmdType, string cmdText, DbTransaction trans, params DbParameter[] commandParameters)
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
    }
}
