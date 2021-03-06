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
    public class registerController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpPost]
        public IHttpActionResult register(Customer c)
        {
            var detail = db.Customers.Where(x => x.Username == c.Username && x.PhoneNumber == c.PhoneNumber).FirstOrDefault();
            if (detail == null)
            {
                db.Customers.Add(c);
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
