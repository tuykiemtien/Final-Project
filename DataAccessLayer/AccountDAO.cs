using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DataAccessLayer
{
    public class AccountDAO
    {
        private string Url = @"http://localhost:59431/api/";
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set => instance = value;
        }

        private AccountDAO() { }



        public AccountDTO Login(AccountDTO account)
        {
            AccountDTO accountDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                var responseTask = client.GetAsync("account?username="+account.Username+"&password="+account.Password);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AccountDTO>();
                    readTask.Wait();
                    accountDTO = readTask.Result;
                }

            }
            return accountDTO;
           
        }
        public AccountDTO GetAccountByUsername(string username)
        {
            AccountDTO accountDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                var responseTask = client.GetAsync("account?username=" + username);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AccountDTO>();
                    readTask.Wait();
                    accountDTO = readTask.Result;
                }

            }
            return accountDTO;

        }

        public bool InsertNewAccount(AccountDTO account)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PostAsJsonAsync("account", account);
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

        public bool PutAccount(AccountDTO account)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                var responseTask = client.PutAsJsonAsync("account", account);
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
