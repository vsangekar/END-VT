using END_VT.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace END_VT.webservice
{
    /// <summary>
    /// Summary description for purchaselist
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class purchaselist : System.Web.Services.WebService
    {

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
    }
}
