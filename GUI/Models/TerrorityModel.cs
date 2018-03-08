using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class TerrorityModel
    {
        private static TerrorityModel instance;

        public static TerrorityModel Instance
        {
            get { if (instance == null) instance = new TerrorityModel(); return TerrorityModel.instance; }
            private set => instance = value;
        }

        private TerrorityModel() { }
    }
}