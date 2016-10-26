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
    public class loginController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpPost]
        public IHttpActionResult login(user u)
        {
            var detail = db.users.Where(x => x.Username == u.Username && x.Password == u.Password).FirstOrDefault();

            if (detail != null)
            {                
                return Ok(JObject.Parse("{success : true}"));
            }
            else
            {               
                return Ok(JObject.Parse("{success : false}"));
            }
        }
    }
}
