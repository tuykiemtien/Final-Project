using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using DTO;

namespace DAO.Controllers
{
    public class SuppliersController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetAllSupplier()
        {
            List<SupplyDTO> list = db.Suppliers.Select(e => new SupplyDTO()
            {
                SupplierID = e.SupplierID,
                CompanyName = e.CompanyName,
                ContactName = e.ContactName,
                ContactTitle = e.ContactTitle,
                Address = e.Address,
                City = e.City,
                Region = e.Region,
                PostalCode = e.PostalCode,
                Country = e.Country,
                Phone = e.Phone,
                Fax = e.Fax,
                HomePage = e.HomePage
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
        public IHttpActionResult GetSupplierById(int id)
        {
            SupplyDTO getId = db.Suppliers.Where(p => p.SupplierID == id).Select(e => new SupplyDTO()
            {
                SupplierID = e.SupplierID,
                CompanyName = e.CompanyName,
                ContactName = e.ContactName,
                ContactTitle = e.ContactTitle,
                Address = e.Address,
                City = e.City,
                Region = e.Region,
                PostalCode = e.PostalCode,
                Country = e.Country,
                Phone = e.Phone,
                Fax = e.Fax,
                HomePage = e.HomePage
            }).FirstOrDefault();
            if (getId != null)
            {
                return Ok(getId);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult PostNewSupplier(SupplyDTO supply)
        {
            Supplier supplierInsert = new Supplier()
            {
                SupplierID = supply.SupplierID,
                CompanyName = supply.CompanyName,
                ContactName = supply.ContactName,
                ContactTitle = supply.ContactTitle,
                Address = supply.Address,
                City = supply.City,
                Region = supply.Region,
                PostalCode = supply.PostalCode,
                Country = supply.Country,
                Phone = supply.Phone,
                Fax = supply.Fax,
                HomePage = supply.HomePage

            };
            db.Suppliers.Add(supplierInsert);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutSupplier(SupplyDTO supply)
        {
            Supplier supplierPut = db.Suppliers.FirstOrDefault(s => s.SupplierID == supply.SupplierID);

            supplierPut.SupplierID = supply.SupplierID;
            supplierPut.CompanyName = supply.CompanyName;
            supplierPut.ContactName = supply.ContactName;
            supplierPut.ContactTitle = supply.ContactTitle;
            supplierPut.Address = supply.Address;
            supplierPut.City = supply.City;
            supplierPut.Region = supply.Region;
            supplierPut.PostalCode = supply.PostalCode;
            supplierPut.Country = supply.Country;
            supplierPut.Phone = supply.Phone;
            supplierPut.Fax = supply.Fax;
            supplierPut.HomePage = supply.HomePage;

            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult DeleteSupplier(int id)
        {
            Supplier supplier = db.Suppliers.FirstOrDefault(s => s.SupplierID == id);
            if (supplier != null )
            {
                db.Suppliers.Remove(supplier);
                if(db.SaveChanges() > 0)
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