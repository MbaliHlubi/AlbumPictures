using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Domains
{
    public class Images
    {
        [Key]
        public Guid image_id { get; set; }

        [Column("name")]
        public string image_name { get; set; }

        [Column("geolocation")]
        public string image_Geolocation{ get; set; }

        [Column("tag")]
        public string image_Tag{ get; set; }

        [Column("capturedDate")]
        public DateTime image_CapturedDate{ get; set; }

        [Column("capturedBy")]
        public string image_CapturedBy{ get; set; }

        [Column("capturedBy")]
        public string album { get; set; }

        [Column("person")]
        public People person { get; set; }

    }
}
