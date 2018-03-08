using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
   public class SupplierBUS
    {
        private static SupplierBUS instance;

        public static SupplierBUS Instance
        {
            get { if (instance == null) instance = new SupplierBUS(); return SupplierBUS.instance; }
            private set => instance = value;
        }

        private SupplierBUS() { }



        public List<SupplyDTO> GetAllSupply()
        {
            List<SupplyDTO> list = SupplierDAO.Instance.GetAllSupply();

            return list;
        }

        public SupplyDTO GetSupplyById(int id)
        {
            SupplyDTO list = SupplierDAO.Instance.GetSupplyById(id);

            return list;
        }

        public bool InsertNewSupply(SupplyDTO supply)
        {
            return SupplierDAO.Instance.InsertNewSupply(supply);
        }

        public bool UpdateSupplier(SupplyDTO supply)
        {
            return SupplierDAO.Instance.UpdateSupplier(supply);
        }

        public bool DeleteSupplier(int id)
        {
            return SupplierDAO.Instance.DeleteSupplier(id);
        }
    }
}
