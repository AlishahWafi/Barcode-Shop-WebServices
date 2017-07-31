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
    public class TopRatingController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpPost]
        [AcceptVerbs("TopRatedPreviousOrder")]
        public IHttpActionResult TopRatedPreviousOrder(Customer cust)
        {
            var query = (from a in db.Products
                         join b in db.OrderLines on a.Product_Id equals b.Product_Id
                         orderby a.AverageRating descending
                         join c in db.Orders on b.Order_Id equals c.Order_Id
                         where c.Customer_Id == cust.Customer_Id

                         select new
                         {
                             a.Product_Id,
                             a.Name,
                             a.AverageRating,
                             a.Image,
                             a.Price,
                             a.Shelf

                         }).Distinct().ToList();

            var data = query.OrderByDescending(s => s.AverageRating);

            return Ok(data);
        }

        [HttpGet]
        [AcceptVerbs("TopRatedProducts")]
        public IHttpActionResult TopRatedProducts()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var prod = db.Products.ToList();

            var prodRate = prod.OrderByDescending(s => s.AverageRating);

            return Ok(prodRate);
        }

        [HttpPost]
        [AcceptVerbs("userRatingDialog")]
        public IHttpActionResult userRatingDialog(Rating r)
        {
            var query = (from a in db.Products
                         join b in db.OrderLines on a.Product_Id equals b.Product_Id
                         orderby a.AverageRating descending
                         join c in db.Orders on b.Order_Id equals c.Order_Id
                         where c.Customer_Id == r.Customer_Id

                         select new
                         {
                             a.Product_Id,

                         }).Distinct().ToList();


            if (query != null)
            {
                foreach (var item in query)
                {
                    if (item.Product_Id == r.Product_Id)
                    {
                        return Ok(JObject.Parse("{success : true}"));
                    }
                }
                return Ok(JObject.Parse("{success : false}"));
            }
            else
            {
                return Ok(JObject.Parse("{success : false}"));
            }
        }

        [HttpPost]
        [AcceptVerbs("userRating")]
        public IHttpActionResult userRating(Rating r)
        {
            var data = db.Ratings.Where(x => x.Customer_Id == r.Customer_Id && x.Product_Id == r.Product_Id).ToList();

            if (data.Count != 0)
            {
                foreach (var item in data)
                {
                    item.Rating1 = r.Rating1;
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
            else
            {
                db.Ratings.Add(r);

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
}
