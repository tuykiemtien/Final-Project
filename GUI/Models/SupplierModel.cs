using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class SupplierModel
    {
        private static SupplierModel instance;

        public static SupplierModel Instance
        {
            get { if (instance == null) instance = new SupplierModel(); return SupplierModel.instance; }
            private set => instance = value;
        }

        private SupplierModel() { }
    }
}