﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthManager.Models
{
    public class AuthenticationRequest
    {
        public string Username { get; set; }    
        public string Password { get; set; }    
    }
}
