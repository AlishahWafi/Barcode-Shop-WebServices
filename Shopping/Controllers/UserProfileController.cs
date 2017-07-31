using Newtonsoft.Json.Linq;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shopping.Controllers
{
    public class UserProfileController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();
        
        [HttpPost]
        public IHttpActionResult userProfile(Customer customer)
        {
            var details = db.Customers.Where(x => x.Username == customer.Username);

            if ( details != null)
            {
                return Ok(details);
            }
            else
            {
                return Ok(JObject.Parse("{sucess : false}"));
            }
        }
    }
}
