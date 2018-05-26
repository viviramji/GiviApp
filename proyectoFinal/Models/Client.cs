using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinal.Models
{
    public class Client
    {
        public string id { get; set; }
        public string companyName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string email { get; set; }
    }
}