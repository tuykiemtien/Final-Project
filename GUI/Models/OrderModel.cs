using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class OrderModel
    {
        private static OrderModel instance;

        public static OrderModel Instance
        {
            get { if (instance == null) instance = new OrderModel(); return OrderModel.instance; }
            private set => instance = value;
        }

        private OrderModel() { }
    }
}