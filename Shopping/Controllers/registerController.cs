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
    public class registerController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpPost]
        public IHttpActionResult register(user u)
        {
            var detail = db.users.Where(x => x.Username == u.Username).FirstOrDefault();
            if (detail == null)
            {
                db.users.Add(u);
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
