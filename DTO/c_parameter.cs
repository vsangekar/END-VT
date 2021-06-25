using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace END_VT.DTO
{
    public class c_parameter
    {
    }

    public class userlogin
    {
        public string username { get; set; }
        public string userpassword { get; set; }
        public string userid { get; set; }

    }

    public class customerreg
    {
        public int cust_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string mobileno { get; set; }
        public string cname { get; set; }
        public string isactive { get; set; }
        public string oldpass { get; set; }
        public string newpass { get; set; }


    }

    public class prodinfo
    {
        public int prodid { get; set; }
        public string pdate { get; set; }
        public string pcname { get; set; }
        public string pname { get; set; }
        public string premarks{ get; set; }
        public string pupload{ get; set; }
        public string pdname{ get; set; }
        public string fileext { get; set; }
        public string filedata { get; set; }
        public string filename { get; set; }
        public string filetype { get; set; }
   

    }

    public class customerotp
    {
        public int otpid { get; set; }
        public string otp { get; set; }
        public string mobileno { get; set; }

    }

    public class customerconfig
    {
        public int configid { get; set; }
        public string tomail { get; set; }
        public string frommail { get; set; }
        public string hostserver { get; set; }
        public string emailbody { get; set; }
        public string emailsubject { get; set; }
        public string password { get; set; }

    }

}