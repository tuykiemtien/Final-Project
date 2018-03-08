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
    public class CustomersController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetAllCustomers()
        {
            List<CustomerDTO> list = db.Customers.Select(e => new CustomerDTO()
            {
                CustomerID = e.CustomerID,
                CompanyName = e.CompanyName,
                ContactName = e.ContactName,
                ContactTitle = e.ContactTitle,
                Address = e.Address,
                City = e.City,
                Region = e.Region,
                PostalCode = e.PostalCode,
                Country = e.Country,
                Phone = e.Phone,
                Fax = e.Fax
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
        public IHttpActionResult GetCustomerById(string id)
        {
            CustomerDTO getId = db.Customers.Where(p => p.CustomerID == id).Select(e => new CustomerDTO()
            {
                CustomerID = e.CustomerID,
                CompanyName = e.CompanyName,
                ContactName = e.ContactName,
                ContactTitle = e.ContactTitle,
                Address = e.Address,
                City = e.City,
                Region = e.Region,
                PostalCode = e.PostalCode,
                Country = e.Country,
                Phone = e.Phone,
                Fax = e.Fax
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
        public IHttpActionResult PostNewCustomer(CustomerDTO customer)
        {
            Customer customPost = new Customer()
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax
            };
            db.Customers.Add(customPost);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutCustomer(CustomerDTO customer)
        {
            Customer customerPut = db.Customers.FirstOrDefault(s => s.CustomerID == customer.CustomerID);

            customerPut.CustomerID = customer.CustomerID;
            customerPut.CompanyName = customer.CompanyName;
            customerPut.ContactName = customer.ContactName;
            customerPut.ContactTitle = customer.ContactTitle;
            customerPut.Address = customer.Address;
            customerPut.City = customer.City;
            customerPut.Region = customer.Region;
            customerPut.PostalCode = customer.PostalCode;
            customerPut.Country = customer.Country;
            customerPut.Phone = customer.Phone;
            customerPut.Fax = customer.Fax;

          
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult DeleteCustomers(string id)
        {
            Customer customer = db.Customers.FirstOrDefault(s => s.CustomerID == id);
            if (customer != null && db.SaveChanges() > 0)
            {
                db.Customers.Remove(customer);
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