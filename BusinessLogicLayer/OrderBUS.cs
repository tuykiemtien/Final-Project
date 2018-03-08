using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

namespace BusinessLogicLayer
{
    public class OrderBUS
    {
        private static OrderBUS instance;

        public static OrderBUS Instance
        {
            get { if (instance == null) instance = new OrderBUS(); return OrderBUS.instance; }
            private set => instance = value;
        }
        private OrderBUS()
        {

        }
        public List<OrderDTO> GetAllOrder()
        {
            List<OrderDTO> list = OrderDAO.Intance.GetAllOrder();
            return list;
        }
        public OrderDTO GetOrderById(int id)
        {
            OrderDTO list = OrderDAO.Intance.GetOrdertById(id);
            return list;
        }
        public bool InsertNewOrder(OrderDTO order)
        {
            return OrderDAO.Intance.UpdateOrder(order);
        }
        public bool UpdateOrder(OrderDTO order)
        {
            return OrderDAO.Intance.UpdateOrder(order);
        }
        public bool DeleteOrder( int id)
        {
            return OrderDAO.Intance.DeleteOrder(id);
        }
    }
}
