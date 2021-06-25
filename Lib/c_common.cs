using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace END_VT.Lib
{
    public class c_common
    {
        string connstr = "";


        public c_common()
        {
            connstr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        public JObject GetJSONString(DataSet ds)
        {
            DataTable Dt = new DataTable();
            StringBuilder Sb = new StringBuilder();
            int rowcount = 0;
            int success = 0;
            if (ds.Tables.Count > 0)
            {
                for (int j = 0; j < ds.Tables.Count; j++)
                {
                    if (j > 0)
                    {
                        if (ds.Tables[j].Rows.Count > 0)
                        {
                            rowcount++;
                        }
                    }
                }

                if (rowcount >= 0)
                {
                    success = 1;
                }
                if (success == 1)
                {
                    for (int k = 0; k < ds.Tables.Count; k++)
                    {
                        if (k == 0)
                        {
                            Sb.Append("{\"" + "success\":\"" + ds.Tables[0].Rows[0][0].ToString() + "\",\"error\":\"" + ds.Tables[0].Rows[0][1].ToString() + "\",");
                        }
                        if (k > 0)
                        {
                            Dt = new DataTable();
                            Dt = ds.Tables[k];
                            if (Dt.Rows.Count > 0)
                            {
                                string[] StrDc = new string[Dt.Columns.Count];
                                string HeadStr = string.Empty;

                                for (int i = 0; i < Dt.Columns.Count; i++)
                                {
                                    StrDc[i] = Dt.Columns[i].Caption.ToLower();
                                    HeadStr += "\"" + StrDc[i] + "\" : \"" + StrDc[i] + i.ToString() + "¾" + "\",";
                                }

                                HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);

                                Sb.Append("\"" + Dt.TableName.ToLower() + "\" : [");

                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    string TempStr = HeadStr;
                                    Sb.Append("{");
                                    for (int j = 0; j < Dt.Columns.Count; j++)
                                    {
                                        TempStr = TempStr.Replace((Dt.Columns[j] + j.ToString()).ToLower() + "¾", Dt.Rows[i][j].ToString().Replace(@"\", "\\\\").Replace("\"", "\\\"").Replace("\'", "\\\'"));
                                    }
                                    Sb.Append(TempStr + "},");
                                }

                                Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));
                                if (k == ds.Tables.Count - 1)
                                {
                                    Sb.Append("]");
                                }
                                else
                                {
                                    Sb.Append("],");
                                }
                            }
                            else
                            {
                                if (k == ds.Tables.Count - 1)
                                {
                                    Sb.Append("\"" + Dt.TableName.ToLower() + "\" : [ ]");
                                }
                                else
                                {
                                    Sb.Append("\"" + Dt.TableName.ToLower() + "\" : [ ],");
                                }
                            }

                        }
                    }
                    Sb.Append("}");
                }
                else
                {
                    Sb.Append("{\"" + "success\":\"0\",\"error\":\"No data available.\"}");
                }
            }
            else
            {
                Sb.Append("{\"" + "success\":\"0\",\"error\":\"No data available.\"}");
            }
            JObject json = JObject.Parse((string)Sb.ToString());
            return json;
        }

        public bool SendEMail(string MailTo, string Subject, string MsgText, string Attachments, string MailFrom, string MailPwd, string HostName, string LinkedResource, ref string refMsg)
        {
            bool success = false;
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(MailFrom, MailTo);
                message.Subject = Subject;
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(MsgText, null, MediaTypeNames.Text.Html);
                message.IsBodyHtml = true;
                success = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.end-vt.com.br";
                string[] Att = null;
                if (Attachments.Length > 0)
                {
                    Att = Attachments.Split(',');

                    foreach (string ma in Att)
                    {
                        System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ma);
                        message.Attachments.Add(attachment);
                    }
                }
                string[] LR = null;
                if (LinkedResource.Length > 0)
                {
                    LR = LinkedResource.Split(',');
                    int i = 0;
                    foreach (string ma in LR)
                    {
                        //Add Image
                        //LinkedResource theEmailImage = new LinkedResource(ma, MediaTypeNames.Image.Jpeg);
                        LinkedResource theEmailImage = new LinkedResource(ma);
                        theEmailImage.ContentId = "myImageID" + i;

                        //Add the Image to the Alternate view
                        htmlView.LinkedResources.Add(theEmailImage);


                        //Add view to the Email Message
                        message.AlternateViews.Add(htmlView);
                        i = i + 1;
                    }
                }
                message.AlternateViews.Add(htmlView);

                if (HostName == "smtp.gmail.com")
                {
                    smtp.EnableSsl = true;
                    smtp.Port = Convert.ToInt32(587);
                }
                else
                {

                    smtp.Port = Convert.ToInt32(25);
                }

                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                NetworkCredential NetworkCred = new NetworkCredential(MailFrom, MailPwd);
                smtp.Credentials = NetworkCred;
                smtp.EnableSsl = true;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                smtp.Send(message);
                message.AlternateViews.Dispose();
                message.Attachments.Dispose();
                message.Dispose();
                refMsg = "Email send successfully to " + MailTo.ToString() + " at " + DateTime.Now;
                success = true;

            }
            catch (Exception ex)
            {
                refMsg = ex.InnerException.Message;
                success = false;
            }
            return success;
        }
    }
}
    