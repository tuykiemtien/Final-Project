using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Net.Http;

namespace DataAccessLayer
{
    public class Order_DetailDAO
    {
        private string Url = @"http://localhost:59431/api/";
        private static Order_DetailDAO instance;

        public static Order_DetailDAO Instance
        {
            get { if (instance == null) instance = new Order_DetailDAO(); return Order_DetailDAO.instance; }
            private set => instance = value;
        }

        private Order_DetailDAO()
        {

        }
        public List<OrderDetailsDTO> GetAllOrder_Detail()
        {
            List<OrderDetailsDTO> list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.GetAsync("order_detail");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<OrderDetailsDTO>>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }
        public OrderDetailsDTO GetOrder_DetailById(int id)
        {
            OrderDetailsDTO list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.GetAsync("order?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OrderDetailsDTO>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }
        public bool InsertNewOrder_Detail(OrderDetailsDTO order_detail)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PostAsJsonAsync<OrderDetailsDTO>("order_detail", order_detail);
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
        public bool UpdateOrder_Detail(OrderDetailsDTO order_detail)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PutAsJsonAsync<OrderDetailsDTO>("order_detail", order_detail);
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
        public bool DeleteOrder_Detail(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.DeleteAsync("order_detail?id=" + id);
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
