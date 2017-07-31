using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Shopping.Controllers
{
    public class ProductController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpPost]
        [AcceptVerbs("GetProduct")]
        public IHttpActionResult GetProduct(Product p)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var details = db.Products.Where(x => x.Barcode == p.Barcode).FirstOrDefault();

            if (details != null)
            {
                return Ok(details);
            }
            else
            {
                return Ok(JObject.Parse("{success : false}"));
            }
        }

        [HttpGet]
        [AcceptVerbs("getProductRating")]
        public IHttpActionResult getProductRating()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var rating = db.Products.ToList();

            if (rating != null)
            {
                return Ok(rating);
            }
            else
                return Ok(JObject.Parse("{success : false}"));
        }
    }
}
