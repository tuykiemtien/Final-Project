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
    public class TerritoriesController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();
        public IHttpActionResult GetAllTerritory()
        {
            List<TerritoryDTO> list = db.Territories.Select(e => new TerritoryDTO()
            {
               TerritoryID = e.TerritoryID,
               TerritoryDescription = e.TerritoryDescription,
               RegionID = e.RegionID
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
        public IHttpActionResult GetTerritoryById(string id)
        {
            TerritoryDTO getId = db.Territories.Where(p => p.TerritoryID == id).Select(e => new TerritoryDTO()
            {
                TerritoryID = e.TerritoryID,
                TerritoryDescription = e.TerritoryDescription,
                RegionID = e.RegionID
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
        public IHttpActionResult PostNewTerritory(TerritoryDTO territory)
        {
            Territory territoryInsert = new Territory()
            {
                TerritoryID = territory.TerritoryID,
                TerritoryDescription = territory.TerritoryDescription,
                RegionID = territory.RegionID
            };
            db.Territories.Add(territoryInsert);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutTerritory(TerritoryDTO territory)
        {
            Territory territoryPut = db.Territories.FirstOrDefault(s => s.TerritoryID == territory.TerritoryID);

            territoryPut.TerritoryID = territory.TerritoryID;
            territoryPut.TerritoryDescription = territory.TerritoryDescription;
            territoryPut.RegionID = territory.RegionID;

            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult DeleteTerritory(string id)
        {
            Territory territory = db.Territories.FirstOrDefault(s => s.TerritoryID == id);
            if (territory != null)
            {
                db.Territories.Remove(territory);
                if (db.SaveChanges() > 0)
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