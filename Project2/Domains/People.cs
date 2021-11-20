using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Domains
{
    public class People
    {
        [Key]
        public Guid person_id { get; set; }

        [Column("name")]
        public string person_name{ get; set; }

        [Column("surname")]
        public string person_surname{ get; set; }

        [Column("username")]
        public string person_userName{ get; set; }

        [Column("password")]
        public string password { get; set; }
    }
}
