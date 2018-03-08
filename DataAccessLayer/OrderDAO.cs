using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using DTO;
namespace DataAccessLayer
{
    public class OrderDAO
    {
        private string Url = @"http://localhost:59431/api/";
        private static OrderDAO instance;

        public static OrderDAO Intance
        {
            get { if (instance == null) instance = new OrderDAO(); return OrderDAO.instance; }
            private set => instance = value;
        }

        private OrderDAO()
        {

        }

        public List<OrderDTO> GetAllOrder()
        {
            List<OrderDTO> list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                var responseTask = client.GetAsync("order");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<OrderDTO>>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }
        public OrderDTO GetOrdertById(int id)
        {
            OrderDTO list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                var responseTask = client.GetAsync("order?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OrderDTO>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }
        public bool InsertNewOrder(OrderDTO order)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PostAsJsonAsync<OrderDTO>("order", order);
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
        public bool UpdateOrder(OrderDTO order)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PutAsJsonAsync<OrderDTO>("order", order);
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
        public bool DeleteOrder(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.DeleteAsync("order?id=" + id);
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
