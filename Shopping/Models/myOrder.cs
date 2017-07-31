using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class myOrder
    {
        public int total_price { get; set; }
        public int customer_id { get; set; }
        public string current_date { get; set; }
    }
}