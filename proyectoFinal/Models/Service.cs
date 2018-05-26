using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinal.Models
{
    public class Service {
        public string id { get; set; }
        public string companyName { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string typeService { get; set; }
        public string adminID { get; set; }
        public string userID { get; set; }
        public string clientID { get; set; }
        public string checker { get; set; }
    }
}