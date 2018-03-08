using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using DTO;
namespace GUI.Models
{
    public class AccountModel
    {
        private static AccountModel instance;

        public static AccountModel Instance
        {
            get { if (instance == null) instance = new AccountModel(); return AccountModel.instance; }
            private set => instance = value;
        }

        private AccountModel() { }

        public bool Register(AccountDTO account)
        {
            return AccountBUS.Instance.InsertNewAccount(account);
        }

        public AccountDTO Login(AccountDTO account)
        {
            return AccountBUS.Instance.Login(account);
        }

        public AccountDTO GetAccountByUsername(string username)
        {
            return AccountBUS.Instance.GetAccountByUsername(username);
        }
        public bool ChangeAccountDetail(AccountDTO account)
        {
            return AccountBUS.Instance.PutAccount(account);
        }
    }
}