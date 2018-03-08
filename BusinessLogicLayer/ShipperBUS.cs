using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ShipperBUS
    {
        private static ShipperBUS instance;

        public static ShipperBUS Instance
        {
            get { if (instance == null) instance = new ShipperBUS(); return ShipperBUS.instance; }
            private set => instance = value;
        }
        private ShipperBUS()
        {

        }
        
        public List<ShipperDTO> GetAllShipper()
        {
            List<ShipperDTO> list = ShipperDAO.Instance.GetAllShiper();
            return list;
        }
        public ShipperDTO GetShipperById(int id)
        {
            ShipperDTO list = ShipperDAO.Instance.GetShipperById(id);
            return list;
        }
        public bool InsertNewShipper(ShipperDTO shipper)
        {
            return ShipperDAO.Instance.InsertNewShipper(shipper);
        }
        public bool UpdateShipper(ShipperDTO shipper)
        {
            return ShipperDAO.Instance.UpdateShipper(shipper);
        }
        public bool DeleteShipper(int id)
        {
            return ShipperDAO.Instance.DeleteShipper(id);
        }
    }
}
