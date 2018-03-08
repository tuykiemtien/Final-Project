using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class CardBUS
    {
        private static CardBUS instance;

        public static CardBUS Instance
        {
            get { if (instance == null) instance = new CardBUS(); return CardBUS.instance; }
            private set => instance = value;
        }

        private CardBUS() { }

        public List<CardDTO> GetAllCard()
        {
            List<CardDTO> list = CardDAO.Instance.GetAllCard();


            return list;
        }

        public List<CardDTO> GetCardById(string id)
        {
            List<CardDTO> list = CardDAO.Instance.GetCardByCustomer(id);

            return list;
        }

        public bool InsertNewCard(CardDTO category)
        {
            return CardDAO.Instance.InsertNewCard(category);
        }

        public bool UpdateCard(CardDTO category)
        {
            return CardDAO.Instance.UpdateCard(category);
        }

        public bool DeleteCard(int id)
        {
            return CardDAO.Instance.DeleteCard(id);
        }
    }
}
