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
    public class EmployeeController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetAllEmployee()
        {
            List<EmployeeDTO> list = db.Employees.Select(e => new EmployeeDTO()
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                EmployeeID = e.EmployeeID,
                PhotoPath = e.PhotoPath,
                Title = e.Title,
                TitleOfCourtesy = e.TitleOfCourtesy,
                HomePhone = e.HomePhone,
                Address = e.Address,
                BirthDate = e.BirthDate,
                City = e.City,
                Country = e.Country,
                Extension = e.Extension,
                HireDate = e.HireDate,
                Notes = e.Notes,
                Photo = e.Photo,
                PostalCode = e.PostalCode,
                Region = e.Region,
                ReportsTo = e.ReportsTo
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

        public IHttpActionResult GetEmployeeById(int id)
        {
            EmployeeDTO list = db.Employees.Where(s => s.EmployeeID == id).Select(e => new EmployeeDTO()
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                EmployeeID = e.EmployeeID,
                PhotoPath = e.PhotoPath,
                Title = e.Title,
                TitleOfCourtesy = e.TitleOfCourtesy,
                HomePhone = e.HomePhone,
                Address = e.Address,
                BirthDate = e.BirthDate,
                City = e.City,
                Country = e.Country,
                Extension = e.Extension,
                HireDate = e.HireDate,
                Notes = e.Notes,
                Photo = e.Photo,
                PostalCode = e.PostalCode,
                Region = e.Region,
                ReportsTo = e.ReportsTo

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

        public IHttpActionResult PostNewEmployee(EmployeeDTO employee)
        {
            Employee employeeInsert = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmployeeID = employee.EmployeeID,
                PhotoPath = employee.PhotoPath,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                HomePhone = employee.HomePhone,
                Address = employee.Address,
                BirthDate = employee.BirthDate,
                City = employee.City,
                Country = employee.Country,
                Extension = employee.Extension,
                HireDate = employee.HireDate,
                Notes = employee.Notes,
                Photo = employee.Photo,
                PostalCode = employee.PostalCode,
                Region = employee.Region,
                ReportsTo = employee.ReportsTo

            };
            db.Employees.Add(employeeInsert);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutEmployee(EmployeeDTO employee)
        {
            Employee employeeInsert = db.Employees.FirstOrDefault(s => s.EmployeeID == employee.EmployeeID);

            employeeInsert.FirstName = employee.FirstName;
            employeeInsert.LastName = employee.LastName;
            employeeInsert.EmployeeID = employee.EmployeeID;
            employeeInsert.PhotoPath = employee.PhotoPath;
            employeeInsert.Title = employee.Title;
            employeeInsert.TitleOfCourtesy = employee.TitleOfCourtesy;
            employeeInsert.HomePhone = employee.HomePhone;
            employeeInsert.Address = employee.Address;
            employeeInsert.BirthDate = employee.BirthDate;
            employeeInsert.City = employee.City;
            employeeInsert.Country = employee.Country;
            employeeInsert.Extension = employee.Extension;
            employeeInsert.HireDate = employee.HireDate;
            employeeInsert.Notes = employee.Notes;
            employeeInsert.Photo = employee.Photo;
            employeeInsert.PostalCode = employee.PostalCode;
            employeeInsert.Region = employee.Region;
            employeeInsert.ReportsTo = employee.ReportsTo;


            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.FirstOrDefault(s => s.EmployeeID == id);
            if (employee != null)
            {
                Account account = db.Accounts.FirstOrDefault(s => s.EmployeeId == id);
                if (account != null)
                {
                    db.Accounts.Remove(account);
                }
                db.Employees.Remove(employee);
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
