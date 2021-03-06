﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularWebApi.Models
{
    public class AccountModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Titre { get; set; }
        public string LoggedOn { get; set; }
    }
}