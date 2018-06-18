using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Truboprovod_V2.Models
{
    public class OstResShirinaContext : DbContext
    {
        public DbSet<OstResShirinaModel> ShirinaRes { get; set; }
    }
}