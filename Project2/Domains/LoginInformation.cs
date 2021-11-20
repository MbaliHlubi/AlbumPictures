using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Domains
{
    public class LoginInformation
    {
        public String username { get; set; }

        public string password { get; set; }
    }
}
