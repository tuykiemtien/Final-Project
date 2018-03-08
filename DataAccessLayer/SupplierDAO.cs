using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SupplierDAO
    {
        private string Url = @"http://localhost:59431/api/";
        private static SupplierDAO instance;

        public static SupplierDAO Instance
        {
            get { if (instance == null) instance = new SupplierDAO(); return SupplierDAO.instance; }
            private set => instance = value;
        }

        private SupplierDAO() { }

        public List<SupplyDTO> GetAllSupply()
        {
            List<SupplyDTO> list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                var responseTask = client.GetAsync("territory");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<SupplyDTO>>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }

        public SupplyDTO GetSupplyById(int id)
        {
            SupplyDTO list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.GetAsync("supplier?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SupplyDTO>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }

        public bool InsertNewSupply(SupplyDTO supply)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PostAsJsonAsync<SupplyDTO>("supplier", supply);
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

        public bool UpdateSupplier(SupplyDTO supply)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PutAsJsonAsync<SupplyDTO>("supplier", supply);
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

        public bool DeleteSupplier(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.DeleteAsync("supplier?id=" + id);
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
