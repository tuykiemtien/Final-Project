using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class RegionBUS
    {
        private static RegionBUS instance;

        public static RegionBUS Instance
        {
            get { if (instance == null) instance = new RegionBUS(); return RegionBUS.instance; }
            private set => instance = value;
        }

        private RegionBUS() { }



        public List<RegionDTO> GetAllRegion()
        {
            List<RegionDTO> list = RegionDAO.Instance.GetAllRegion();

            return list;
        }

        public RegionDTO GetRegionById(int id)
        {
            RegionDTO list = RegionDAO.Instance.GetRegionById(id);

            return list;
        }

        public bool InsertNewRegion(RegionDTO region)
        {
            return RegionDAO.Instance.InsertNewRegion(region);
        }

        public bool UpdateRegion(RegionDTO supply)
        {
            return RegionDAO.Instance.UpdateRegion(supply);
        }

        public bool DeleteRegion(int id)
        {
            return RegionDAO.Instance.DeleteRegion(id);
        }
    }
}
