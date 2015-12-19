using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace NWCMADemoApp.Models.AdminModel
{
    [Serializable]
    public class LoginModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public int LoginType { get; set; }
        public string LoginName { get; set; }

    }
}