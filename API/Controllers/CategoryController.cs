using API.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CategoryController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetAllCategory()
        {
            List<CategoryDTO> list = db.Categories.Select(e => new CategoryDTO()
            {
                CategoryID = e.CategoryID,
                CategoryName = e.CategoryName,
                Description = e.Description,
                CategoryImage = e.CategoryImage
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

        public IHttpActionResult GetCategoryById(int id)
        {
            CategoryDTO list = db.Categories.Where(s => s.CategoryID == id).Select(e => new CategoryDTO()
            {
                CategoryID = e.CategoryID,
                CategoryName = e.CategoryName,
                Description = e.Description,
                CategoryImage = e.CategoryImage
            }).FirstOrDefault();

            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult PostNewCategory(CategoryDTO cate)
        {
            Category category = new Category()
            {
                CategoryID = cate.CategoryID,
                CategoryName = cate.CategoryName,
                Description = cate.Description,
                CategoryImage = cate.CategoryImage
            };
            db.Categories.Add(category);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutCategory(CategoryDTO cate)
        {
            Category category = db.Categories.FirstOrDefault(s => s.CategoryID == cate.CategoryID);

            category.CategoryName = cate.CategoryName;
            category.Description = cate.Description;
            category.CategoryImage = cate.CategoryImage;


            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.FirstOrDefault(s => s.CategoryID == id);
            if (category != null)
            {
               
  
                db.Categories.Remove(category);
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
