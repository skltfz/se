using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace StockMaximumGain
{
    class db
    {
        public static string sqlconnection ="";
        private System.Data.SqlClient.SqlConnection condbstr()
        {//HY-PC\STOCK//(local)
            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(sqlconnection);
            return sqlConn;//ConfigurationManager.AppSettings["sqlname"]
        }
        public DataTable powerselect(string done)
        {
            String tmp = done;
            return execute(tmp);
        }
        public static DataTable spowerselect(string done)
        {
            String tmp = done;
            return exe(tmp);
        }
        public db()
        {
            sqlconnection = System.Configuration.ConfigurationManager.AppSettings["sqlString"];
        }
        public DataTable select(string what, string dbn, string where,string order)
        {
            String tmp = "Select " + what + " from " + dbn;
            if (!where.Equals(""))
                tmp = tmp + " where " + where;
            if(!order.Equals("")) tmp = tmp + " order by "+order;
            return execute(tmp);
        }
        public string seb(string x)
        {
            //string embrace
            return "'" + x + "'";
        }
        public static string sseb(string x)
        {
            //string embrace
            return "'" + x + "'";
        }
        public string nseb(string x)
        {
            //string embrace
            return "N'" + x + "'";
        }
        public string delete(string table, string[] fields, string[] values)//with ' ' for delete field, which can be deleted if you are not processing string
        {
            string query = "DELETE FROM " + table + " WHERE ";
            for (int u = 0; u < fields.Length; u++)
            {
                query = query + fields[u] + "=" + values[u];
                if (u < fields.Length - 1) query = query + " AND ";
            }
            execute2(query);
            return query;
        }
        public void updateN(string table, object[] column, object[] value, string id, string tid)
        {
            string query = "UPDATE " + table + " SET ";
            for (int sv = 0; sv < column.Length; sv++)
                query = query + embrace(column[sv].ToString()) + "= N'" + value[sv] + ",";
            query = query.TrimEnd(',');
            query = query + " where " + id + " = " + seb(tid);
            execute2(query);
        }
        public void update(string table, object[] column, object[] value, string id, string tid)
        {
            string query = "UPDATE " + table + " SET ";
            for (int sv = 0; sv < column.Length; sv++)
                query = query + embrace(column[sv].ToString()) + "= " + value[sv] + ",";
            query = query.TrimEnd(',');
            query = query + " where " + id + " = " + seb(tid);
            execute2(query);
        }
        public void update_free(string table, object[] column, object[] value, string where)
        {
            string query = "UPDATE " + table + " SET ";
            for (int sv = 0; sv < column.Length; sv++)
                query = query + embrace(column[sv].ToString()) + "= " + value[sv] + ",";
            query = query.TrimEnd(',');
            query = query + " where " + where;
            execute2(query);
        }
        private string embrace(string x)
        {
            return "[" + x + "]";
        }
        public void insert(string table, object[] column, object[] value)
        {
            string query = "INSERT INTO " + table + " (";
            foreach (object g in column)
                query = query + embrace(g.ToString()) + ",";
            query = query.TrimEnd(',');
            query = query + ") VALUES (";
            foreach (object g in value)
                query = query + g.ToString() + ",";
            query = query.TrimEnd(',');
            query = query + ")";
            execute2(query);
        }
        private void execute2(string strSQL)
        {
            //OleDbConnection objConnection = oledbStr();
            //objConnection.Open();
            //OleDbCommand objCmd = null;
            System.Data.SqlClient.SqlConnection sqlConn = condbstr();
            sqlConn.Open();
            System.Data.SqlClient.SqlCommand dataCommand = new System.Data.SqlClient.SqlCommand();
            dataCommand.Connection = sqlConn;
            dataCommand.CommandText = strSQL;
            dataCommand.ExecuteNonQuery();
            sqlConn.Close();
        }
        private DataTable execute(string strSQL)
        {
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(sqlconnection))
            using (System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConn))
            {
                sqlConn.Open();
                //System.Data.SqlClient.SqlCommand SqlCmd = new System.Data.SqlClient.SqlCommand(strSQL, sqlConn);
                DataTable ds = new DataTable();
                adapter.Fill(ds);
                return ds;
            }
        }
        private static DataTable exe(string strSQL)
        {
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(sqlconnection))
            using (System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConn))
            {
                sqlConn.Open();
                //System.Data.SqlClient.SqlCommand SqlCmd = new System.Data.SqlClient.SqlCommand(strSQL, sqlConn);
                DataTable ds = new DataTable();
                adapter.Fill(ds);
                return ds;
            }
        }
    }
}
