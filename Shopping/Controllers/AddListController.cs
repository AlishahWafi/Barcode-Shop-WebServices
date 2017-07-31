using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Shopping.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Shopping.Controllers
{
    public class AddListController : ApiController
    {
        DBShoppingEntities db = new DBShoppingEntities();

        [HttpPost]
        public IHttpActionResult getOrder(Test order)
        {
            var data = order;

            if (data != null)
            {
                //myOrder mo = JsonConvert.DeserializeObject<myOrder>(data.ToString());


                var customerid = data.customer_id;
                //var date = data.current_date;
                var tprice = data.total_price;

                Order ord = new Order
                {
                    Customer_Id = customerid,
                    OrderDate = System.DateTime.Now.Date,
                    Total_Price = Convert.ToDouble(tprice),
                    BillPayed = false
                };
            
                var orderResponse = db.Orders.Add(ord);
                int orderId = 0;
                try
                {
                    db.SaveChanges();
                    orderId = orderResponse.Order_Id;
                }
                catch (Exception e)
                {
                }

                //OrderlineViewModel ol = JsonConvert.DeserializeObject<OrderlineViewModel>(data.ToString());
                //var json = ol.jsonData;

                //var ho = JsonConvert.DeserializeObject<List<myOrderLine>>(json);

                foreach (var item in data.jsonData)
                {
                    var productid = item.mproduct_id;
                    var name = item.name;
                    double qty = Convert.ToDouble(item.Qty);
                    double price = Convert.ToDouble(item.price);

                    OrderLine ordline = new OrderLine
                    {
                        Order_Id = orderId,
                        Product_Id = productid,
                        Price = Convert.ToDouble(price),
                        Quantity = Convert.ToInt32(qty),
                        LineTotal = price * qty
                    };

                    db.OrderLines.Add(ordline);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        ord = db.Orders.Find(orderId);
                        db.Orders.Remove(ord);
                        db.SaveChanges();

                        return Ok(JObject.Parse("{success : false}"));
                    }

                }

                return Ok(JObject.Parse("{success : true}"));
            }
            else
            {
                return Ok(JObject.Parse("{success : false}"));
            }
        }
    }
}