using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinal.Models
{
    public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }
        public string typeUser { get; set; }
        public string mySqlStatus { get; set; }
    }
}