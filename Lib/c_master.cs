using END_VT.Controllers;
using END_VT.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace END_VT.Lib
{
    public class c_master
    {
        string connstr = ""; 


        public c_master()
        {
            connstr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }
        public DataSet checkforrecordexists(string mobileno, string email, int refid, string reftype)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_t_checkforrecordexists", conn);
                sqlComm.Parameters.AddWithValue("mobileno", mobileno);
                sqlComm.Parameters.AddWithValue("emailid", email);
                sqlComm.Parameters.AddWithValue("refid", refid);
                sqlComm.Parameters.AddWithValue("reftype", reftype);
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

        public DataSet insertcustomer(customerreg cr)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_t_insertcustomer", conn);
                sqlComm.Parameters.AddWithValue("isactive", cr.isactive);
                sqlComm.Parameters.AddWithValue("name", cr.name);
                sqlComm.Parameters.AddWithValue("email", cr.email);
                sqlComm.Parameters.AddWithValue("password", cr.password);
                sqlComm.Parameters.AddWithValue("mobileno", cr.mobileno);
                sqlComm.Parameters.AddWithValue("cname", cr.cname);
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

        public DataSet updatecustomer(customerreg cr)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_t_updatecustomer", conn);
                sqlComm.Parameters.AddWithValue("custid", cr.cust_id);
                sqlComm.Parameters.AddWithValue("custname", cr.name);
                sqlComm.Parameters.AddWithValue("emailid", cr.email);
                sqlComm.Parameters.AddWithValue("cmobileno", cr.mobileno);
                sqlComm.Parameters.AddWithValue("comname", cr.cname);
                sqlComm.Parameters.AddWithValue("is_active", cr.isactive);
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

        public DataSet checkforproductexists(string pname, string reftype,int refid)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_t_checkforproductexists", conn);
                sqlComm.Parameters.AddWithValue("pname", pname);
                sqlComm.Parameters.AddWithValue("reftype", reftype);
                sqlComm.Parameters.AddWithValue("refid", refid);
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

        public DataSet insertprodinfo(prodinfo cr)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_t_insertproduct", conn);
                sqlComm.Parameters.AddWithValue("pdate", cr.pdate);
                sqlComm.Parameters.AddWithValue("pcname", cr.pcname);
                sqlComm.Parameters.AddWithValue("pname", cr.pname);
                sqlComm.Parameters.AddWithValue("premarks", cr.premarks);
                sqlComm.Parameters.AddWithValue("pupload", cr.pupload);
                sqlComm.Parameters.AddWithValue("pdname", cr.pdname);
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

        public DataSet getcustomerdatabyid(customerreg sdata)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_m_getcustomerdatabyid", conn);
                sqlComm.Parameters.AddWithValue("custid", sdata.cust_id);
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

        public DataSet deletecustomerdatabyid(customerreg sdata)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_m_deletecustomerdatabyid", conn);
                sqlComm.Parameters.AddWithValue("custid", sdata.cust_id);
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

        public DataSet updateproductdata(prodinfo cr)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_t_updateproduct", conn);
                sqlComm.Parameters.AddWithValue("prodid", cr.prodid);
                sqlComm.Parameters.AddWithValue("pdate", cr.pdate);
                sqlComm.Parameters.AddWithValue("pcname", cr.pcname);
                sqlComm.Parameters.AddWithValue("pname", cr.pname);
                sqlComm.Parameters.AddWithValue("premarks", cr.premarks);
                sqlComm.Parameters.AddWithValue("pupload", cr.pupload);
                sqlComm.Parameters.AddWithValue("pdname", cr.pdname);
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

        public DataSet getproductdatabyid(prodinfo sdata)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_m_getproddatabyid", conn);
                sqlComm.Parameters.AddWithValue("prod_id", sdata.prodid);
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

        public DataSet deleteproductdatabyid(prodinfo sdata)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_m_deleteproductdatabyid", conn);
                sqlComm.Parameters.AddWithValue("prod_id", sdata.prodid);
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

        public DataSet getstudentdoc(int refid)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_m_getstudentdoc", conn);
                sqlComm.Parameters.AddWithValue("refid", refid);
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
        public DataSet customerlogin(customerreg sdata)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("prt_api_customerlogin", conn);
                sqlComm.Parameters.AddWithValue("emailid", sdata.email);
                sqlComm.Parameters.AddWithValue("custpassword", sdata.password);
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

        public DataSet forgetpassword(customerreg gid)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("prt_api_forgetpasssword", conn);
                sqlComm.Parameters.AddWithValue("emailid", gid.email);
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

        public DataSet getpassword(customerotp sdata)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("pr_api_forgetpassword", conn);
                sqlComm.Parameters.AddWithValue("otp_m", sdata.otp);
                sqlComm.Parameters.AddWithValue("mobile_no", sdata.mobileno);
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

        public DataSet changepassword(customerreg sdata)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                MySqlCommand sqlComm = new MySqlCommand("p_api_changepassword", conn);
                sqlComm.Parameters.AddWithValue("custid", sdata.cust_id);
                sqlComm.Parameters.AddWithValue("newpass", sdata.newpass);
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

        public bool SendSMS(string mobileno, string msgtext)
        {
            string refMsg = "";
            DataSet ds = new DataSet();
            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string DocID = ds.Tables[0].Rows[i]["DocID"].ToString();
                    string UserID = ds.Tables[0].Rows[i]["UserID"].ToString();
                    string Password = CryptoEngine.Decrypt(ds.Tables[0].Rows[i]["Password"].ToString(), true);
                    string HostServer = ds.Tables[0].Rows[i]["HostServer"].ToString();
                    string APIUrl = ds.Tables[0].Rows[i]["APIUrl"].ToString();
                    string Channel = ds.Tables[0].Rows[i]["Channel"].ToString();
                    string DCS = ds.Tables[0].Rows[i]["DCS"].ToString();
                    string flashsms = ds.Tables[0].Rows[i]["flashsms"].ToString();
                    string routeno = ds.Tables[0].Rows[i]["routeno"].ToString();
                    string APIKey = ds.Tables[0].Rows[i]["APIKey"].ToString();
                    string sendto = mobileno;
                    string smsmsg = msgtext;
                    nc.SMS.SendSMS(APIUrl, UserID, Password, HostServer, Channel, DCS, flashsms, routeno, APIKey, smsmsg, sendto, ref refMsg);

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}