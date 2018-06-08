using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Truboprovod_V2.Models
{
    public class KoefsContext : DbContext
    {

        public DbSet<Usloviya_neSer> usl_neSer { get; set; }
        public DbSet<Soprotivleniya> sopr { get; set; }
    }
}