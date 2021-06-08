﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class ApplicationUsers :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public byte[] Profile { get; set; }
    }
}
