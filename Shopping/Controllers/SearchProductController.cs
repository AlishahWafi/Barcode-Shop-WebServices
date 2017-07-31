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
    public class SearchProductController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpPost]
        public IHttpActionResult search(Product p)
        {
            var detail = db.Products.Where(x => x.Name.Contains(p.Name) || x.Name.StartsWith(p.Name) || x.Name.EndsWith(p.Name));

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
