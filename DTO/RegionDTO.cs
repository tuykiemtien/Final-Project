using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RegionDTO
    {
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
        public virtual ICollection<TerritoryDTO> Territories { get; set; }
    }
}
