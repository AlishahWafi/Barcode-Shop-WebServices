using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        DBShoppingEntities db = new DBShoppingEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.stockDetails = db.Products
               .Where(model => model.Stock < 11)
               .Select(model => model.Name).ToList();

            //stock count
            var count = db.Products.Where(a => a.Stock < 11);
            var c = count.Count();

            //customer count
            var customerCount = db.Customers.Count();

            ViewBag.stock = c;
            ViewBag.customerCount = customerCount;

            //popular products

            var data = from p in db.OrderLines
                       group p by p.Product_Id into pg
                       join o in db.Orders
                       on pg.FirstOrDefault().Order_Id equals o.Order_Id
                       where (o.OrderDate.Month == System.DateTime.Now.Month)
                       select new
                       {
                           total = pg.Sum(s => s.LineTotal),
                           prodName = pg.FirstOrDefault().Product.Name
                       };

            List<string> monthlysale = new List<string>();

            foreach (var item in data)
            {
                var a = item.prodName;
                var b = item.total;
                var combine = a + " - Rs" + b;

                monthlysale.Add(combine);

            }

            ViewBag.monthlySale = monthlysale;

            return View();
        }
    }
}