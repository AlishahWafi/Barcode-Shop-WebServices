﻿using Newtonsoft.Json.Linq;
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
        public IHttpActionResult login(Customer c)
        {
            var detail = db.Customers.Where(x => x.Username == c.Username && x.Password == c.Password).FirstOrDefault();

            if (detail != null)
            {
                return Ok(detail);
            }
            else
            {                        
                return Ok(JObject.Parse("{success : false}"));
            }
        }
    }
}
