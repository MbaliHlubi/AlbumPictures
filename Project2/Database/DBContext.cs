using Microsoft.EntityFrameworkCore;
using Project2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Database
{
    public class DBContext :DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options){}

        public DbSet<People> people { get; set; }
        
        public DbSet<Images> images { get; set; }
    }
}
