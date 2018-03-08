using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using API.Models;

namespace API.Controllers
{
    public class AccountController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();
        
        [HttpGet]
        public IHttpActionResult Login(string username, string password)
        {
            AccountDTO account = db.Accounts.Where(s => s.Username == username && s.Password == password).Select(a => new AccountDTO()
            {
                Username = a.Username,
                Password = a.Password,
                CustomerId = a.CustomerId,
                EmployeeId = a.EmployeeId
            }).FirstOrDefault();
            if(account != null)
            {
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult PostNewAccount(AccountDTO acc)
        {
            Account account = new Account()
            {
                Username = acc.Username,
                CustomerId = acc.CustomerId,
                Password = acc.Password,
                Email = acc.Email,
                EmployeeId = acc.EmployeeId
            };
            db.Accounts.Add(account);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult PutAccount(AccountDTO acc)
        {
            Account account = db.Accounts.FirstOrDefault(s => s.Username == acc.Username);
            account.Username = acc.Username;
            account.Password = acc.Password;
            account.Email = acc.Email;
            if(acc.EmployeeId != null)
            {
                account.EmployeeId = acc.EmployeeId;
            }
            if(acc.CustomerId != null)
            {
                account.CustomerId = acc.CustomerId;
            }


            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult DeleteAccount(string username)
        {
            Account account = db.Accounts.FirstOrDefault(s => s.Username == username);
            db.Accounts.Remove(account);
            if(db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        public IHttpActionResult GetAccountByUsername(string username)
        {
            AccountDTO account = db.Accounts.Where(s => s.Username == username).Select(a => new AccountDTO()
            {
                Username = a.Username,
                Password = a.Password,
                CustomerId = a.CustomerId,
                Email = a.Email,
                EmployeeId = a.EmployeeId
            }).FirstOrDefault();
            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
