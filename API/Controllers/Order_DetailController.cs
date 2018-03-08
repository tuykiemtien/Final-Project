using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using DTO;

namespace API.Controllers
{
    public class Order_DetailController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetAllOrder_Detail()
        {
            List<OrderDetailsDTO> list = db.Order_Details.Select(e => new OrderDetailsDTO()
            {
                OrderID = e.OrderID,
                ProductID = e.ProductID,
                Product = new ProductDTO()
                {
                    ProductID = e.Product.ProductID,
                    ProductName = e.Product.ProductName
                },
                UnitPrice = e.UnitPrice,
                Quantity = e.Quantity,
                Discount = e.Discount
            }).ToList();
            if (list.Count > 0)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult GetOrder_DetailId(int id)
        {
            OrderDetailsDTO list = db.Order_Details.Where(a => a.OrderID == id).Select(e => new OrderDetailsDTO()
            {
                OrderID = e.OrderID,
                ProductID = e.ProductID,
                Product = new ProductDTO()
                {
                    ProductID = e.Product.ProductID,
                    ProductName = e.Product.ProductName
                },
                UnitPrice = e.UnitPrice,
                Quantity = e.Quantity,
                Discount = e.Discount
            }).FirstOrDefault();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult PostNewOrder_Detail(OrderDetailsDTO order_detail)
        {
            Order_Detail order_detailInsert = new Order_Detail()
            {
                OrderID = order_detail.OrderID,
                ProductID = order_detail.ProductID,
                UnitPrice = order_detail.UnitPrice,
                Quantity = order_detail.Quantity,
                Discount = order_detail.Discount
            };
            db.Order_Details.Add(order_detailInsert);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutOrder_Detail(OrderDetailsDTO order_detail)
        {
            Order_Detail order_detailEdit = db.Order_Details.FirstOrDefault(s => s.OrderID == order_detail.OrderID);

            order_detailEdit.OrderID = order_detail.OrderID;
            order_detailEdit.ProductID = order_detail.ProductID;
            order_detailEdit.UnitPrice = order_detail.UnitPrice;
            order_detailEdit.Quantity = order_detail.Quantity;
            order_detailEdit.Discount = order_detail.Discount;
 
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult DeleteOrder_Detail(int id)
        {
            Order_Detail order_detai = db.Order_Details.FirstOrDefault(s => s.OrderID == id);
            if (order_detai != null)
            {
                db.Order_Details.Remove(order_detai);
                if (db.SaveChanges() > 0)
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
