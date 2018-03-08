using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using BusinessLogicLayer;

namespace GUI.Models
{
    public class CustomerModel
    {
        private static CustomerModel instance;

        public static CustomerModel Instance
        {
            get { if (instance == null) instance = new CustomerModel(); return CustomerModel.instance; }
            private set => instance = value;
        }

        private CustomerModel() { }

        public bool InsertNewCustomer(CustomerDTO customer)
        {
            return CustomersBUS.Instance.InsertNewCustomer(customer);
        }
        public List<CustomerDTO> GetAllCustomer()
        {
            return CustomersBUS.Instance.GetAllCustomers();
        }
    }
}