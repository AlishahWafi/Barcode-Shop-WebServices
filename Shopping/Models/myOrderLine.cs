using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class myOrderLine
    {
        public int Qty { get; set; }
        public int mproduct_id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
    }
}