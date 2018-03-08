using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TerrorityDAO
    {
        private string Url = @"http://localhost:59431/api/";
        private static TerrorityDAO instance;

        public static TerrorityDAO Instance
        {
            get { if (instance == null) instance = new TerrorityDAO(); return TerrorityDAO.instance; }
            private set => instance = value;
        }

        private TerrorityDAO() { }

        public List<TerritoryDTO> GetAllTerritory()
        {
            List<TerritoryDTO> list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                var responseTask = client.GetAsync("territory");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<TerritoryDTO>>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }

        public TerritoryDTO GetTerritoryById(string id)
        {
            TerritoryDTO list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.GetAsync("customer?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TerritoryDTO>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }

        public bool InsertNewTerritory(TerritoryDTO territory)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PostAsJsonAsync<TerritoryDTO>("territory", territory);
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

        public bool UpdateTerritory(TerritoryDTO territory)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PutAsJsonAsync<TerritoryDTO>("territory", territory);
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

        public bool DeleteTerritory(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.DeleteAsync("territory?id=" + id);
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
