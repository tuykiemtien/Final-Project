using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class TerritoryBUS
    {
        private static TerritoryBUS instance;

        public static TerritoryBUS Instance
        {
            get { if (instance == null) instance = new TerritoryBUS(); return TerritoryBUS.instance; }
            private set => instance = value;
        }

        private TerritoryBUS() { }



        public List<TerritoryDTO> GetAllTerritory()
        {
            List<TerritoryDTO> list = TerrorityDAO.Instance.GetAllTerritory();

            return list;
        }

        public TerritoryDTO GetTerritoryById(string id)
        {
            TerritoryDTO list = TerrorityDAO.Instance.GetTerritoryById(id);

            return list;
        }

        public bool InsertNewTerritory(TerritoryDTO supply)
        {
            return TerrorityDAO.Instance.InsertNewTerritory(supply);
        }

        public bool UpdateTerritory(TerritoryDTO supply)
        {
            return TerrorityDAO.Instance.UpdateTerritory(supply);
        }

        public bool DeleteTerritory(string id)
        {
            return TerrorityDAO.Instance.DeleteTerritory(id);
        }
    }
}
