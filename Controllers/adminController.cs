using END_VT.DTO;
using END_VT.Lib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.Services;

namespace END_VT.Controllers
{
    public class adminController : ApiController
    {
        [HttpPost]
        public JObject userlogin(userlogin ul)
        {
            c_common cc = new c_common();
            c_admin ca = new c_admin();
            DataSet ds = new DataSet();
            try
            {
                //string data = CryptorEngine.Encrypt("mXia3pz1", true);
                ul.userpassword = CryptoEngine.Encrypt(ul.userpassword, true);
                ds = ca.userlogin(ul);
                if (ds.Tables.Count == 1)
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"" + ds.Tables[0].Rows[0]["success"].ToString() + "\",\"error\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
                    JObject json = JObject.Parse((string)Sb.ToString());
                    return json;
                }
                else
                {
                    ds.Tables[1].TableName = "userdata";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HttpContext.Current.Session["userid"] = ds.Tables[1].Rows[0]["userid"].ToString();
                        HttpContext.Current.Session["fullname"] = ds.Tables[1].Rows[0]["empname"].ToString();
                        return cc.GetJSONString(ds);
                    }
                    else
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"Sorry !! No data available.\"}");
                        JObject json = JObject.Parse((string)Sb.ToString());
                        return json;
                    }

                }

            }
            catch (Exception ex)
            {
                StringBuilder Sb = new StringBuilder();
                Sb.Append("{\"" + "success\":\"-1\",\"error\":\"" + ex.Message + "\"}");
                JObject json = JObject.Parse((string)Sb.ToString());
                return json;

            }
        }


        [HttpPost]
        public JObject getallcustomerlist()
        {
            c_common cc = new c_common();
            c_admin ca = new c_admin();
            DataSet ds = new DataSet();
            try
            {
                if (HttpContext.Current.Session.Count > 0)
                {
                    userlogin ui = new userlogin();
                    ui.userid = HttpContext.Current.Session["userid"].ToString();
                    ds = ca.getallcustomerlist();
                    ds.Tables[1].TableName = "customerdata";
                    return cc.GetJSONString(ds);
                }
                else
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"-2\",\"error\":\"Sorry !! Session is expired.\"}");
                    JObject json = JObject.Parse((string)Sb.ToString());
                    return json;
                }


            }
            catch (Exception ex)
            {
                StringBuilder Sb = new StringBuilder();
                Sb.Append("{\"" + "success\":\"-1\",\"error\":\"" + ex.Message + "\"}");
                JObject json = JObject.Parse((string)Sb.ToString());
                return json;

            }
        }

        [HttpPost]
        public JObject getallpurchaselist()
        {
            c_common cc = new c_common();
            c_admin ca = new c_admin();
            DataSet ds = new DataSet();
            string Folder = System.Web.HttpContext.Current.Server.MapPath("~/uploaddoc");
            try
            {
                if (HttpContext.Current.Session.Count > 0)
                {
                    userlogin ui = new userlogin();
                    ui.userid = HttpContext.Current.Session["userid"].ToString();
                    ds = ca.getallpurchaselist();
                    for (var i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        string fullpath = Path.Combine(Folder, ds.Tables[1].Rows[i]["pupload"].ToString());
                        if (!File.Exists(fullpath))
                        {
                            ds.Tables[1].Rows[i]["pupload"] ="";
                        }
                    }
                    ds.Tables[1].TableName = "purchasedata";
                    return cc.GetJSONString(ds);
                }
                else
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"-2\",\"error\":\"Sorry !! Session is expired.\"}");
                    JObject json = JObject.Parse((string)Sb.ToString());
                    return json;
                }


            }
            catch (Exception ex)
            {
                StringBuilder Sb = new StringBuilder();
                Sb.Append("{\"" + "success\":\"-1\",\"error\":\"" + ex.Message + "\"}");
                JObject json = JObject.Parse((string)Sb.ToString());
                return json;

            }
        }

        [HttpPost]
        public JObject clearsessiononlogout()
        {
            try
            {
                c_common cc = new c_common();
                DataSet ds = new DataSet();
                if (HttpContext.Current.Session.Count > 0)
                {
                    //if exists then clear all session veriable
                    HttpContext.Current.Session.Clear();
                    HttpContext.Current.Session.RemoveAll();
                    HttpContext.Current.Session.Abandon();
                }


                StringBuilder Sb = new StringBuilder();
                Sb.Append("{\"" + "success\":\"1\",\"error\":\"You are successfully logout from application.\"}");
                JObject json = JObject.Parse((string)Sb.ToString());
                return json;

            }
            catch (Exception ex)
            {
                StringBuilder Sb = new StringBuilder();
                Sb.Append("{\"" + "success\":\"0\",\"error\":\"" + ex.Message + "\"}");
                JObject json = JObject.Parse((string)Sb.ToString());
                return json;
            }

        }

        [HttpPost]
        public JObject getdataafterlogin()
        {
            c_common cc = new c_common();
            c_admin ca = new c_admin();
            DataSet ds = new DataSet();
            try
            {
                if (HttpContext.Current.Session.Count > 0)
                {
                    userlogin ui = new userlogin();
                    ui.userid = HttpContext.Current.Session["userid"].ToString();
                    ds = ca.getdataafterlogin(ui);
                    ds.Tables[1].TableName = "userdata";
                    return cc.GetJSONString(ds);
                }
                else
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"-2\",\"error\":\"Sorry !! Session is expired.\"}");
                    JObject json = JObject.Parse((string)Sb.ToString());
                    return json;
                }


            }
            catch (Exception ex)
            {
                StringBuilder Sb = new StringBuilder();
                Sb.Append("{\"" + "success\":\"-1\",\"error\":\"" + ex.Message + "\"}");
                JObject json = JObject.Parse((string)Sb.ToString());
                return json;

            }
        }

        [HttpPost]
        public JObject uploaddocument()
        {
            c_common cc = new c_common();
            DataSet ds = new DataSet();
            StringBuilder Sb = new StringBuilder();
            try
            {
                if (HttpContext.Current.Session.Count > 0)
                {
                    NameValueCollection collection = HttpContext.Current.Request.Form;
                    var items = collection.AllKeys.SelectMany(collection.GetValues, (k, v) => new { key = k, value = v });
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    if (items.Count() > 0)
                    {
                        if (HttpContext.Current.Request.Files.Count > 0)
                        {
                            string extension = System.IO.Path.GetExtension(HttpContext.Current.Request.Files[0].FileName);
                            BinaryReader br = new BinaryReader(HttpContext.Current.Request.Files[0].InputStream);
                            byte[] binaryReader = br.ReadBytes((int)HttpContext.Current.Request.Files[0].InputStream.Length);

                            string base64String = Convert.ToBase64String(binaryReader, 0, binaryReader.Length);
                            DataTable table1 = new DataTable();
                            table1.Columns.Add("success");
                            table1.Columns.Add("error");
                            table1.Rows.Add("1", "");
                            ds.Tables.Add(table1);
                            DataTable table2 = new DataTable();
                            table2.Columns.Add("filename");
                            table2.Columns.Add("filedata");
                            table2.Columns.Add("fileext");
                            table2.Rows.Add(HttpContext.Current.Request.Files[0].FileName, base64String, extension);
                            ds.Tables.Add(table2);
                            ds.Tables[1].TableName = "filedata";
                            return cc.GetJSONString(ds);
                        }
                        else
                        {
                            Sb = new StringBuilder();
                            Sb.Append("{\"" + "success\":\"0\",\"error\":\"Sorry!! No file present to upload.\"}");
                            JObject json = JObject.Parse((string)Sb.ToString());
                            return json;
                        }
                    }
                    else
                    {
                        Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"Sorry!! No file present to upload.\"}");
                        JObject json = JObject.Parse((string)Sb.ToString());
                        return json;
                    }
                }
                else
                {
                    Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"-2\",\"error\":\"Sorry !! Session is expired.\"}");
                    JObject json = JObject.Parse((string)Sb.ToString());
                    return json;
                }
            }
            catch (Exception ex)
            {
                Sb = new StringBuilder();
                Sb.Append("{\"" + "success\":\"-1\",\"error\":\"" + ex.Message + "\"}");
                JObject json = JObject.Parse((string)Sb.ToString());
                return json;

            }
        }

        //[WebMethod]
        //public static List<customerreg> getcustcollist()
        //{
        //    string connstr = "";
        //    connstr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        //    MySqlConnection conn = new MySqlConnection(connstr);
        //    DataTable dt = new DataTable();
        //    List<customerreg> objcust = new List<customerreg>();
        //    try
        //    {

        //        if (conn.State != ConnectionState.Open)
        //            conn.Open();
        //        MySqlCommand MysqlComm = new MySqlCommand("select cust_id,name from customerreg", conn);
        //        MySqlDataAdapter da = new MySqlDataAdapter(MysqlComm);
        //        da.Fill(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                objcust.Add(new customerreg
        //                {
        //                    cust_id = Convert.ToInt32(dt.Rows[i]["cust_id"]),
        //                    name = dt.Rows[i]["name"].ToString()
        //                });
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        conn.Close();
        //    }
        //    return objcust;
        //}

        [HttpPost]
        public JObject getcustcollist(customerreg cdata)
        {
            c_common cc = new c_common();
            c_admin ca = new c_admin();
            DataSet ds = new DataSet();
            try
            {
                ds = ca.getcustcollist(cdata);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count == 1)
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"" + ds.Tables[0].Rows[0]["success"].ToString() + "\",\"error\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
                        JObject json = JObject.Parse((string)Sb.ToString());
                        return json;
                    }
                    else
                    {
                        ds.Tables[1].TableName = "customerdata";
                        return cc.GetJSONString(ds);
                    }
                }
                else
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"0\",\"error\":\"Sorry !! No data available.\"}");
                    JObject json = JObject.Parse((string)Sb.ToString());
                    return json;
                }
            }
            catch (Exception ex)
            {
                StringBuilder Sb = new StringBuilder();
                Sb.Append("{\"" + "success\":\"-1\",\"error\":\"" + ex.Message + "\"}");
                JObject json = JObject.Parse((string)Sb.ToString());
                return json;

            }
        }

        [HttpPost]
        public JObject post([FromBody] customerreg gid)
        {
            DataSet ds = new DataSet();
            c_common cc = new c_common();
            c_admin ca = new c_admin();
            string returnmsg = "";
            bool process = true;
            try
            {

                if (process == true)
                {

                    ds = ca.forgetpassword(gid);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables.Count == 1)
                        {
                            StringBuilder Sb = new StringBuilder();
                            Sb.Append("{\"" + "success\":\"" + ds.Tables[0].Rows[0]["success"].ToString() + "\",\"error\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
                            JObject json = JObject.Parse((string)Sb.ToString());
                            return json;
                        }
                        else
                        {
                            for (var i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                string FromMailID = ds.Tables[1].Rows[i]["frommail"].ToString();
                                string MailPassword = ds.Tables[1].Rows[i]["configpassword"].ToString();
                                string HostName = ds.Tables[1].Rows[i]["hostserver"].ToString();

                                string SendTo = ds.Tables[1].Rows[i]["email"].ToString();
                                string EmailSubject = ds.Tables[1].Rows[i]["emailsubject"].ToString();
                                string emailbody = ds.Tables[1].Rows[i]["emailbody"].ToString().Replace("configpassword", ds.Tables[1].Rows[i]["configpassword"].ToString());
                                string filename = System.Web.HttpContext.Current.Server.MapPath("~/images/") + "login.jpg";
                                cc.SendEMail(SendTo, EmailSubject, emailbody, "", FromMailID, MailPassword, HostName, filename, ref returnmsg);
                            }

                            if (returnmsg.Contains("Email send successfully to"))
                            {
                                StringBuilder Sb = new StringBuilder();
                                Sb.Append("{\"" + "success\":\"" + ds.Tables[0].Rows[0]["success"].ToString() + "\",\"error\":\"" + returnmsg + "\"}");
                                JObject json = JObject.Parse((string)Sb.ToString());
                                return json;
                            }
                            else
                            {
                                StringBuilder Sb = new StringBuilder();
                                Sb.Append("{\"" + "success\":\"0\",\"error\":\"" + returnmsg + "\"}");
                                JObject json = JObject.Parse((string)Sb.ToString());
                                return json;
                            }


                        }
                    }
                    else
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"Sorry!! No Rows available\"}");
                        JObject json = JObject.Parse((string)Sb.ToString());
                        return json;
                    }
                }
                else
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"-1\",\"error\":\"Sorry !! Session is expired.\"}");
                    JObject json = JObject.Parse((string)Sb.ToString());
                    return json;
                }
            }
            catch (Exception ex)
            {
                StringBuilder Sb = new StringBuilder();
                Sb.Append("{\"" + "success\":\"0\",\"error\":\"" + ex.Message + "\"}");
                JObject json = JObject.Parse((string)Sb.ToString());
                return json;
            }
        }

    }
}


    