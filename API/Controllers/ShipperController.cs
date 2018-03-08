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
    public class ShipperController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetAllShipper()
        {
            List<ShipperDTO> list = db.Shippers.Select(e => new ShipperDTO()
            {
                ShipperID = e.ShipperID,
                CompanyName = e.CompanyName,
                Phone = e.Phone
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

        public IHttpActionResult GetShipperById(int id)
        {
            ShipperDTO list = db.Shippers.Where(s => s.ShipperID == id).Select(e => new ShipperDTO()
            {
                CompanyName = e.CompanyName,
                Phone = e.Phone
              

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

        public IHttpActionResult PostNewShipper(ShipperDTO shiper)
        {
            Shipper shipperInsert = new Shipper()
            {
                CompanyName = shiper.CompanyName,
                Phone = shiper.Phone

            };
            db.Shippers.Add(shipperInsert);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutShipper(ShipperDTO shipper)
        {
            Shipper shipperEdit = db.Shippers.FirstOrDefault(s => s.ShipperID == shipper.ShipperID);

            shipperEdit.CompanyName = shipper.CompanyName;
            shipperEdit.Phone = shipper.Phone;

            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult DeleteShipper(int id)
        {
            Shipper shipper = db.Shippers.FirstOrDefault(s => s.ShipperID == id);
            if (shipper != null)
            {
                db.Shippers.Remove(shipper);
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
