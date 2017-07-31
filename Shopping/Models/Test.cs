using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class Test
    {
        public int customer_id { get; set; }
        public List<TestProduct> jsonData { get; set; }
        public String total_price { get; set; }
    }
}