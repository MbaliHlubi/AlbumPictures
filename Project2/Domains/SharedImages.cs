using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Domains
{
    public class SharedImages
    {
        public Guid person_id { get; set; }
        [Key]
        [Column("person_id_from")]
        [ForeignKey("person_id")]
        public People person { get; set; }


        public Guid image_id { get; set; }

        [Key]
        [Column("image_id")]
        [ForeignKey("image_id")]
        public Images image { get; set; }

        [Key]
        [Column("sent_to")]
        public string sendTo { get; set; }
    }
}
