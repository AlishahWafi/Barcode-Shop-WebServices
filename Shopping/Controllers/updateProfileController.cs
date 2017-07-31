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
    public class updateProfileController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpPost]
        public IHttpActionResult updateProfile(Customer c)
        {
            var query = from result in db.Customers
                        where result.Username == c.Username
                        select result;

            foreach (Customer result in query)
            {
                result.Name = c.Name;
                result.Password = c.Password;
            }
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return Ok(JObject.Parse("{success : true}"));
            }
            else
            {
                return Ok(JObject.Parse("{success : false}"));
            }
        }
    }
}
