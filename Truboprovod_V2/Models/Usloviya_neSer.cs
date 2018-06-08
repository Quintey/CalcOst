using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Truboprovod_V2.Models
{
    public class Usloviya_neSer
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public double Koef_m2 { get; set; }
    }
}