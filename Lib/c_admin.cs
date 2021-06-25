using END_VT.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Services;

namespace END_VT.Lib
{
    public class c_admin
    {
        string connstr = "";
        public c_admin()
        {
            connstr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }
        public DataSet userlogin(userlogin ul)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_t_userlogin", conn);
                sqlComm.Parameters.AddWithValue("username", ul.username);
                sqlComm.Parameters.AddWithValue("userpassword", ul.userpassword);
                sqlComm.CommandTimeout = 0;
                sqlComm.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
            return ds;
        }

        public DataSet getallcustomerlist()
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand MysqlComm = new MySqlCommand("pr_m_getallcustomerlist", conn);
                MysqlComm.CommandTimeout = 0;
                MysqlComm.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = MysqlComm;
                da.Fill(ds);
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
            }
            return ds;
        }

        public DataSet getallpurchaselist()
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand MysqlComm = new MySqlCommand("pr_m_getallpurchaselist", conn);
                MysqlComm.CommandTimeout = 0;
                MysqlComm.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = MysqlComm;
                da.Fill(ds);
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
            }
            return ds;
        }
        public DataSet getdataafterlogin(userlogin uinfo)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_m_getdataafterlogin", conn);
                sqlComm.Parameters.AddWithValue("userid", uinfo.userid);
                sqlComm.CommandTimeout = 0;
                sqlComm.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
            return ds;
        }

        public DataSet getcustcollist(customerreg cdata)
        {
            DataSet ds = new DataSet();

            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand MysqlComm = new MySqlCommand("pr_m_getcustcollist", conn);
                MysqlComm.CommandTimeout = 0;
                MysqlComm.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = MysqlComm;
                da.Fill(ds);
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
            return ds;

        }

        [WebMethod]
        public static List<customerreg> getcustcollist()
        {
            string connstr = "";
            connstr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connstr);
            DataTable dt = new DataTable();
            List<customerreg> objcust = new List<customerreg>();
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand MysqlComm = new MySqlCommand("select cust_id,name from customerreg", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(MysqlComm);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objcust.Add(new customerreg
                        {
                            cust_id = Convert.ToInt32(dt.Rows[i]["cust_id"]),
                            name = dt.Rows[i]["name"].ToString()
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                conn.Close();
            }
            return objcust;
        }
        public DataSet forgetpassword(customerreg gid)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("prt_ap_forgetpasssword", conn);
                sqlComm.Parameters.AddWithValue("email_id", gid.email);
                sqlComm.CommandTimeout = 0;
                sqlComm.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
            }
            return ds;
        }
    }
}