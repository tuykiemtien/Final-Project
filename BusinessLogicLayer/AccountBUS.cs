using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class AccountBUS
    {

        private static AccountBUS instance;

        public static AccountBUS Instance
        {
            get { if (instance == null) instance = new AccountBUS(); return AccountBUS.instance; }
            private set => instance = value;
        }

        private AccountBUS() { }



        public AccountDTO Login(AccountDTO account)
        {
            AccountDTO accountDTO = AccountDAO.Instance.Login(account);
            return accountDTO;

        }
        public AccountDTO GetAccountByUsername(string username)
        {
            return AccountDAO.Instance.GetAccountByUsername(username);
        }
        public bool InsertNewAccount(AccountDTO account)
        {
            return AccountDAO.Instance.InsertNewAccount(account);
        }

        public bool PutAccount(AccountDTO account)
        {
            return AccountDAO.Instance.PutAccount(account);
        }
    }
}
