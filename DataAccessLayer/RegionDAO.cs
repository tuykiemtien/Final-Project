using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RegionDAO
    {
        private string Url = @"http://localhost:59431/api/";
        private static RegionDAO instance;

        public static RegionDAO Instance
        {
            get { if (instance == null) instance = new RegionDAO(); return RegionDAO.instance; }
            private set => instance = value;
        }

        private RegionDAO() { }

        public List<RegionDTO> GetAllRegion()
        {
            List<RegionDTO> list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                var responseTask = client.GetAsync("regions");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<RegionDTO>>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }

        public RegionDTO GetRegionById(int id)
        {
            RegionDTO list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.GetAsync("regions?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RegionDTO>();
                    readTask.Wait();
                    list = readTask.Result;
                }
            }
            return list;
        }

        public bool InsertNewRegion(RegionDTO region)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PostAsJsonAsync<RegionDTO>("regions", region);
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

        public bool UpdateRegion(RegionDTO region)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PutAsJsonAsync<RegionDTO>("regions", region);
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

        public bool DeleteRegion(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.DeleteAsync("regions?id=" + id);
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
