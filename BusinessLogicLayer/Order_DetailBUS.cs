using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class Order_DetailBUS
    {
        private static Order_DetailBUS instance;

        public static Order_DetailBUS Instance
        {
            get { if (instance == null) instance = new Order_DetailBUS(); return Order_DetailBUS.instance; }
            private set => instance = value;
        }

        private Order_DetailBUS() { }



        public List<OrderDetailsDTO> GetAllOrder_Detail()
        {
            List<OrderDetailsDTO> list = Order_DetailDAO.Instance.GetAllOrder_Detail();

            return list;
        }

        public OrderDetailsDTO GetOrder_DetailById(int id)
        {
            OrderDetailsDTO list = Order_DetailDAO.Instance.GetOrder_DetailById(id);

            return list;
        }

        public bool InsertNewOrder_Detail(OrderDetailsDTO order_detail)
        {
            return Order_DetailDAO.Instance.InsertNewOrder_Detail(order_detail);

        }

        public bool UpdateOrder_Detail(OrderDetailsDTO order_detail)
        {
            return Order_DetailDAO.Instance.UpdateOrder_Detail(order_detail);
        }

        public bool DeleteOrder_Detail(int id)
        {
            return Order_DetailDAO.Instance.DeleteOrder_Detail(id);
        }
    }
}
