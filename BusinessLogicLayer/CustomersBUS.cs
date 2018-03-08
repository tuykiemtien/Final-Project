using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
   public  class CustomersBUS
    {
        private static CustomersBUS instance;

        public static CustomersBUS Instance
        {
            get { if (instance == null) instance = new CustomersBUS(); return CustomersBUS.instance; }
            private set => instance = value;
        }

        private CustomersBUS() { }



        public List<CustomerDTO> GetAllCustomers()
        {
            List<CustomerDTO> list = CustomerDAO.Instance.GetAllCustomers();

            return list;
        }

        public CustomerDTO GetCustomerById(string id)
        {
            CustomerDTO list = CustomerDAO.Instance.GetCustomerById(id);

            return list;
        }

        public bool InsertNewCustomer(CustomerDTO customer)
        {
            return CustomerDAO.Instance.InsertNewEmployee(customer);
        }

        public bool UpdateCustomer(CustomerDTO customer)
        {
            return CustomerDAO.Instance.UpdateCustomer(customer);
        }

        public bool DeleteCustomer(string id)
        {
            return CustomerDAO.Instance.DeleteCustomer(id);
        }
    }
}
