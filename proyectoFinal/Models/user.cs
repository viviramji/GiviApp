﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinal.Models
{
    public class User
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string city { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string typeUser { get; set; }
    }
}