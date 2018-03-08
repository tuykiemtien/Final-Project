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
    public class OrderController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetAllOrder()
        {
            List<OrderDTO> list = db.Orders.Select(e => new OrderDTO()
            {
                OrderID = e.OrderID,
                CustomerID = e.CustomerID,
                EmployeeID = e.EmployeeID,
                OrderDate = e.OrderDate,
                ShipName = e.ShipName,
                Shipper = new ShipperDTO()
                {
                    ShipperID = e.Shipper.ShipperID,
                    CompanyName = e.Shipper.CompanyName
                }
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
        public IHttpActionResult GetOrderId(int id)
        {
            OrderDTO list = db.Orders.Where(a => a.OrderID == id).Select(e => new OrderDTO()
            {
                OrderID = e.OrderID,
                CustomerID = e.CustomerID,
                EmployeeID = e.EmployeeID,
                OrderDate = e.OrderDate,
                RequiredDate = e.RequiredDate,
                ShippedDate = e.ShippedDate,
                ShipVia = e.ShipVia,
                Freight = e.Freight,
                ShipName = e.ShipName,
                ShipAddress = e.ShipAddress,
                ShipCity = e.ShipCity,
                ShipRegion = e.ShipRegion,
                ShipPostalCode = e.ShipPostalCode,
                ShipCountry = e.ShipCountry,
                Shipper = new ShipperDTO()
                {
                    ShipperID = e.Shipper.ShipperID,
                    CompanyName = e.Shipper.CompanyName
                }
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
        public IHttpActionResult PostNewOrder(OrderDTO order)
        {
            Order orderInsert = new Order()
            {
                CustomerID = order.CustomerID,
                EmployeeID = order.EmployeeID,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
            };
            db.Orders.Add(orderInsert);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutOrder(OrderDTO order)
        {
            Order orderEdit = db.Orders.FirstOrDefault(s => s.OrderID == order.OrderID);


            orderEdit.CustomerID = order.CustomerID;
            orderEdit.EmployeeID = order.EmployeeID;
            orderEdit.OrderDate = order.OrderDate;
            orderEdit.RequiredDate = order.RequiredDate;
            orderEdit.ShippedDate = order.ShippedDate;
            orderEdit.ShipVia = order.ShipVia;
            orderEdit.Freight = order.Freight;
            orderEdit.ShipName = order.ShipName;
            orderEdit.ShipAddress = order.ShipAddress;
            orderEdit.ShipCity = order.ShipCity;
            orderEdit.ShipRegion = order.ShipRegion;
            orderEdit.ShipPostalCode = order.ShipPostalCode;
            orderEdit.ShipCountry = order.ShipCountry;

            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = db.Orders.FirstOrDefault(s => s.OrderID == id);
            if (order != null)
            {
                db.Orders.Remove(order);
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
