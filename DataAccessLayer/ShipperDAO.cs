using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Net.Http;
namespace DataAccessLayer
{
   public class ShipperDAO
    {
        private string Url = @"http://localhost:59431/api/";
        private static ShipperDAO instance;

        public static ShipperDAO Instance
        {
            get { if (instance == null) instance = new ShipperDAO(); return ShipperDAO.instance; }
            private set => instance = value;
        }

        private ShipperDAO()
        {

        }
        public List<ShipperDTO> GetAllShiper()
        {
            List<ShipperDTO> list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.GetAsync("shipper");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ShipperDTO>>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }
        public ShipperDTO GetShipperById(int id)
        {
            ShipperDTO list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.GetAsync("shipper?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ShipperDTO>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }
        public bool InsertNewShipper(ShipperDTO shipper)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PostAsJsonAsync<ShipperDTO>("shipper", shipper);
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
        public bool UpdateShipper(ShipperDTO shipper)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PutAsJsonAsync<ShipperDTO>("shipper", shipper);
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
        public bool DeleteShipper(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.DeleteAsync("shipper?id=" + id);
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
