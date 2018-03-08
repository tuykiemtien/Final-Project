using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class ShipperModel
    {
        private static ShipperModel instance;

        public static ShipperModel Instance
        {
            get { if (instance == null) instance = new ShipperModel(); return ShipperModel.instance; }
            private set => instance = value;
        }

        private ShipperModel() { }
    }
}