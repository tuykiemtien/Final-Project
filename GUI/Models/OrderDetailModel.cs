using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class OrderDetailModel
    {
        private static OrderDetailModel instance;

        public static OrderDetailModel Instance
        {
            get { if (instance == null) instance = new OrderDetailModel(); return OrderDetailModel.instance; }
            private set => instance = value;
        }

        private OrderDetailModel() { }
    }
}