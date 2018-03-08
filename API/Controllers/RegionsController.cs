using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using DTO;

namespace DAO.Controllers
{
    public class RegionsController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetAllRegion()
        {
            List<RegionDTO> list = db.Regions.Select(e => new RegionDTO()
            {
               RegionID = e.RegionID,
               RegionDescription = e.RegionDescription
            }).ToList();

            if (list.Count > 0)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult GetRegionById(int id)
        {
            RegionDTO getId = db.Regions.Where(p => p.RegionID == id).Select(e => new RegionDTO()
            {
                RegionID = e.RegionID,
                RegionDescription = e.RegionDescription
            }).FirstOrDefault();
            if (getId != null)
            {
                return Ok(getId);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult PostNewRegion(RegionDTO region)
        {
            Region regionPost = new Region()
            {
                RegionID = region.RegionID,
                RegionDescription = region.RegionDescription
            };
            db.Regions.Add(regionPost);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutRegion(RegionDTO region)
        {
            Region regionPut = db.Regions.FirstOrDefault(s => s.RegionID == region.RegionID);

            regionPut.RegionID = region.RegionID;
            regionPut.RegionDescription = region.RegionDescription;

            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult DeleteRegion(int id)
        {
            Region region = db.Regions.FirstOrDefault(s => s.RegionID == id);
            if (region != null)
            {
                db.Regions.Remove(region);
                if(db.SaveChanges() > 0)
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }

            }
            else
            {
                return NotFound();
            }
        }
    }
}