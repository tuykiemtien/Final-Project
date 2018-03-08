using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private string Url = @"http://localhost:59431/api/";
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return CustomerDAO.instance; }
            private set => instance = value;
        }

        private CustomerDAO() { }

        public List<CustomerDTO> GetAllCustomers()
        {
            List<CustomerDTO> list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                var responseTask = client.GetAsync("customers");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<CustomerDTO>>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }

        public CustomerDTO GetCustomerById(string id)
        {
            CustomerDTO list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.GetAsync("customer?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CustomerDTO>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }

        public bool InsertNewEmployee(CustomerDTO customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PostAsJsonAsync<CustomerDTO>("customers", customer);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateCustomer(CustomerDTO customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PutAsJsonAsync<CustomerDTO>("customers", customer);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteCustomer(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.DeleteAsync("customer?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
