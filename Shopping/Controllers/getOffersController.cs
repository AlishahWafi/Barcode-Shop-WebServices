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
    public class getOffersController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpGet]
        public IHttpActionResult getOffers(Offer offer)
        {
            var details = db.Offers;
            if (details != null)
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
