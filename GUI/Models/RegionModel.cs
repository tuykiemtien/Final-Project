using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using BusinessLogicLayer;
namespace GUI.Models
{
    public class RegionModel
    {
        private static RegionModel instance;

        public static RegionModel Instance
        {
            get { if (instance == null) instance = new RegionModel(); return RegionModel.instance; }
            private set => instance = value;
        }

        private RegionModel() { }

        
    }
}