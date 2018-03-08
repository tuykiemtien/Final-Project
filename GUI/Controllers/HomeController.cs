using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using GUI.Models;
namespace GUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(AccountDTO account)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Ok = false });
            }

            bool check = AccountModel.Instance.Register(account);
            if (check)
            {
                Session["username"] = account.Username;
                return Json(new { Ok = true });
            }
            else
            {
                return Json(new { Ok = false });
            }
            

        }

        [HttpPost]
        public JsonResult Login(AccountDTO account)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Ok = "error" });
            }
            AccountDTO accountDTO = AccountModel.Instance.Login(account);
            if(accountDTO != null)
            {
                Session["username"] = accountDTO.Username;
                if(accountDTO.EmployeeId != null)
                {
                    EmployeeDTO employee = EmployeeModel.Instance.GetEmployeeById(accountDTO.EmployeeId.Value);
                    if(employee.ReportsTo != null)
                    {
                        Session["role"] = "sales";
                    }
                    else
                    {
                        Session["role"] = "admin";
                    }
                    return Json(new { Ok = "employee" });
                }
                else if(accountDTO.CustomerId == null)
                {
                    return Json(new { Ok = "not finish" });
                }
                else
                {
                    return Json(new { Ok = "finish" });
                }                             
            }
            else
            {
                return Json(new { Ok = "error" });
            }
        }


        public ActionResult About()
        {    
            if(Session.Count <= 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public JsonResult Customer(CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Ok = false });
            }
            string strId = customer.CompanyName.Substring(0, 3);
            strId = strId.ToUpper();
            List<CustomerDTO> list = CustomerModel.Instance.GetAllCustomer();
            CustomerDTO customerDTO = list.Where(s => s.CustomerID.Substring(0,3).Equals(strId)).LastOrDefault();
            if(customerDTO != null)
            {
                string strEndId = customerDTO.CustomerID.Substring(3);
                int intCheck = 0;
                if(int.TryParse(strEndId, out intCheck))
                {
                    intCheck++;
                    if(intCheck < 10)
                    {
                        strId = strId + "0" + intCheck.ToString();
                        
                    }
                    else
                    {
                        strId = strId + intCheck.ToString();
                    }
                }
                else
                {
                    intCheck++;
                    strId = strId + "0" + intCheck.ToString();
                }
            }
            else
            {
                strId = strId + "01";
            }

            customer.CustomerID = strId;
            if (CustomerModel.Instance.InsertNewCustomer(customer))
            {
                AccountDTO account = AccountModel.Instance.GetAccountByUsername(Session["username"].ToString());
                account.CustomerId = customer.CustomerID;
                AccountModel.Instance.ChangeAccountDetail(account);
                return Json(new { Ok = true });
            }
            else
            {
                return Json(new { Ok = false });
            }

        }

    }
}