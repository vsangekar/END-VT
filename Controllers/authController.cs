using END_VT.DTO;
using END_VT.Lib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace END_VT.Controllers
{
    public class authController : ApiController
    {
        [HttpPost]
        public JObject insertcustomerprofile(customerreg cdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            try
            {
                DataSet dscheck = ca.checkforrecordexists(cdata.mobileno, cdata.email, 0, "cust");
                if (dscheck.Tables[0].Rows[0][0].ToString() == "1")
                {
                    customerreg sm = new customerreg();
                    sm.name = cdata.name;
                    sm.email = cdata.email;
                    sm.password = cdata.password;
                    sm.mobileno = cdata.mobileno;
                    sm.cname = cdata.cname;
                    sm.isactive = cdata.isactive;
                    ds = ca.insertcustomer(sm);
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
                        Sb.Append("{\"" + "success\":\"" + dscheck.Tables[0].Rows[0][0].ToString() + "\",\"error\":\"" + dscheck.Tables[0].Rows[0][1].ToString() + "\"}");
                        JObject json = JObject.Parse((string)Sb.ToString());
                        return json;
                    }
                }
                else
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"" + dscheck.Tables[0].Rows[0][0].ToString() + "\",\"error\":\"" + dscheck.Tables[0].Rows[0][1].ToString() + "\"}");
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
        public JObject updatecustomerprofile(customerreg cdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            try
            {  
                    ds = ca.updatecustomer(cdata);
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
        public JObject insertprodinfo(prodinfo cdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            string Folder = System.Web.HttpContext.Current.Server.MapPath("~/uploaddoc");
            int prodid = 0;
            try
            {
                DataSet dscheck = ca.checkforproductexists(cdata.pname, "prod",cdata.prodid);
                if (dscheck.Tables[0].Rows[0][0].ToString() == "1")
                {
                    prodinfo sm = new prodinfo();                
                    sm.pdate = cdata.pdate;
                    sm.pcname = cdata.pcname;
                    sm.pname = cdata.pname;
                    sm.premarks = cdata.premarks;
                    sm.pdname = cdata.pdname;

                    if (cdata.filedata != null)
                    {
                        if (cdata.filedata.Length > 0)
                        {
                            string fname = "uploaddoc" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + cdata.fileext;
                            string filePath = Path.Combine(Folder, fname);
                            File.WriteAllBytes(filePath, Convert.FromBase64String(cdata.filedata));
                            sm.pupload = fname;
                        }
                        //if (cdata.filetype == "noturl")
                        //{
                        //    DataSet dsdoc = ca.getstudentdoc(prodid);
                        //    for (int i = 0; i < dsdoc.Tables[0].Rows.Count; i++)
                        //    {
                        //        string fullpath = Path.Combine(Folder, dsdoc.Tables[0].Rows[i]["pupload"].ToString());
                        //        if (File.Exists(fullpath))
                        //        {
                        //            File.Delete(fullpath);
                        //        }
                        //    }
                        //}
                    }
                    ds = ca.insertprodinfo(sm);
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
                            ds.Tables[1].TableName = "productdata";
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
                else
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"" + dscheck.Tables[0].Rows[0][0].ToString() + "\",\"error\":\"" + dscheck.Tables[0].Rows[0][1].ToString() + "\"}");
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
        public JObject getcustomerdatabyid(customerreg sdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            try
            {
                ds = ca.getcustomerdatabyid(sdata);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count == 1)
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
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
        public JObject deletecustomerdatabyid(customerreg sdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            try
            {
                ds = ca.deletecustomerdatabyid(sdata);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count == 1)
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
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
        public JObject updateproductdata(prodinfo pdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            int prodid = 0;
            string Folder = System.Web.HttpContext.Current.Server.MapPath("~/uploaddoc");
            try
            {
                ds = ca.updateproductdata(pdata);
                prodid = Convert.ToInt32(pdata.prodid);
                if (pdata.filedata != null)
                {
                    if (pdata.filetype == "noturl")
                    {
                        DataSet dsdoc = ca.getstudentdoc(prodid);
                        for (int i = 0; i < dsdoc.Tables[0].Rows.Count; i++)
                        {
                            string fullpath = Path.Combine(Folder, dsdoc.Tables[0].Rows[i]["pupload"].ToString());
                            if (File.Exists(fullpath))
                            {
                                File.Delete(fullpath);
                            }
                        }
                        if (pdata.filedata.Length > 0)
                        {
                            string fname = "uploaddoc" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + pdata.fileext;
                            string filePath = Path.Combine(Folder, fname);
                            File.WriteAllBytes(filePath, Convert.FromBase64String(pdata.filedata));
                            prodinfo sm = new prodinfo();
                            sm.prodid = prodid;
                            sm.pupload = fname;
                            ca.insertprodinfo(sm);
                        }
                    }
                }
                else
                {
                    DataSet dsdoc = ca.getstudentdoc(prodid);
                    for (int i = 0; i < dsdoc.Tables[0].Rows.Count; i++)
                    {
                        string fullpath = Path.Combine(Folder, dsdoc.Tables[0].Rows[i]["pupload"].ToString());
                        if (File.Exists(fullpath))
                        {
                            File.Delete(fullpath);
                        }
                    }
                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count == 1)
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
                        JObject json = JObject.Parse((string)Sb.ToString());
                        return json;
                    }
                    else
                    {

                        ds.Tables[1].TableName = "productdata";
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
        public JObject updatefiledata()
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

                            //  byte[] compressbinaryReader = cc.Compress(binaryReader);

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

        [HttpPost]
        public JObject getproductdatabyid(prodinfo sdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            try
            {
                ds = ca.getproductdatabyid(sdata);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count == 1)
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
                        JObject json = JObject.Parse((string)Sb.ToString());
                        return json;
                    }
                    else
                    {

                        ds.Tables[1].TableName = "productdata";
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
        public JObject deleteproductdatabyid(prodinfo sdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            try
            {
                ds = ca.deleteproductdatabyid(sdata);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count == 1)
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
                        JObject json = JObject.Parse((string)Sb.ToString());
                        return json;
                    }
                    else
                    {

                        ds.Tables[1].TableName = "productdata";
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
        public JObject customerlogin(customerreg sdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            string email = "";
            string password = "";
            try
            {
                //string data = CryptorEngine.Encrypt("mXia3pz1", true);
                //sdata.password = CryptoEngine.Encrypt(sdata.password, true);
                ds = ca.customerlogin(sdata);
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
                    if (ds.Tables[0].Rows.Count > 0)
                    {                      
                        return cc.GetJSONString(ds);
                    }
                    else
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"Sorry !! invalid emaid id and password.\"}");
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
        public JObject forgetpassword(customerreg sdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            string email = "";
            string password = "";
            try
            {
                ds = ca.forgetpassword(sdata);
                if (ds.Tables.Count == 1)
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"" + ds.Tables[0].Rows[0]["success"].ToString() + "\",\"otp\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
                    JObject json = JObject.Parse((string)Sb.ToString());
                    return json;
                }
                else
                {
                    ds.Tables[1].TableName = "customerdata";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return cc.GetJSONString(ds);
                    }
                    else
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"Sorry !! invalid emaid id and password.\"}");
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
        public JObject getpassword(customerotp sdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            try
            {
                ds = ca.getpassword(sdata);
                if (ds.Tables.Count == 1)
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"" + ds.Tables[0].Rows[0]["success"].ToString() + "\",\"error\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
                    JObject json = JObject.Parse((string)Sb.ToString());
                    return json;
                }
                else
                {
                    ds.Tables[1].TableName = "customerotp";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return cc.GetJSONString(ds);
                    }
                    else
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"Sorry !! invalid emaid id and password.\"}");
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
        public JObject changepassword(customerreg sdata)
        {
            c_common cc = new c_common();
            c_master ca = new c_master();
            DataSet ds = new DataSet();
            try
            {
                ds = ca.changepassword(sdata);
                if (ds.Tables.Count == 1)
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.Append("{\"" + "success\":\"" + ds.Tables[0].Rows[0]["success"].ToString() + "\",\"error\":\"" + ds.Tables[0].Rows[0]["ReturnMsg"].ToString() + "\"}");
                    JObject json = JObject.Parse((string)Sb.ToString());
                    return json;
                }
                else
                {
                    ds.Tables[1].TableName = "customerreg";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return cc.GetJSONString(ds);
                    }
                    else
                    {
                        StringBuilder Sb = new StringBuilder();
                        Sb.Append("{\"" + "success\":\"0\",\"error\":\"Sorry !! invalid emaid id and password.\"}");
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
    }
}