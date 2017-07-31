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
    public class walletController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpPost]
        public IHttpActionResult getWallet(Customer c)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var wallet = db.Customers
                        .Where(x => x.Customer_Id == c.Customer_Id);

            if (wallet != null)
            {
                return Ok(wallet);
            }
            else
            {
                return Ok(JObject.Parse("{success : false}"));
            }
        }
    }
}
