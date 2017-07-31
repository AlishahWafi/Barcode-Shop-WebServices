using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shopping.Models;
using Newtonsoft.Json.Linq;

namespace Shopping.Controllers
{
    public class PreviousOrderController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpPost]
        public IHttpActionResult getPreviousOrder(Customer cust)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Orders.Where(x => x.Customer_Id == cust.Customer_Id).ToList();

            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return Ok(JObject.Parse("{success : false}"));
            }
        }
    }
}
