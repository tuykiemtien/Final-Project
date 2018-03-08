using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using GUI.Models;
using PagedList;
using PagedList.Mvc;
namespace GUI.Controllers
{
    public class IndexController : Controller
    {


        // GET: Index
        public ActionResult Index(int? page, string search, int? pageSize)
        {
            List<ProductDTO> list = ProductModel.Instance.GetAllProduct();
            if (search != null)
            {
                list = list.Where(s => s.ProductName.Contains(search)).ToList();
            }
            int pageNumber = (page ?? 1);
            int pageSizePage = (pageSize ?? 12);
            ViewBag.CategoryList = CategoryModel.Instance.GetAllCategory();
            List<ProductDTO> productList = ProductModel.Instance.GetAllProduct();
            var listResponse = list.OrderBy(s => s.ProductID).ToPagedList(pageNumber, pageSizePage);
            return PartialView("Index", listResponse);
        }

        public ActionResult SearchByCategory(int id, int? page, int? pageSize)
        {
            ViewBag.CategoryList = CategoryModel.Instance.GetAllCategory();
            List<ProductDTO> list = ProductModel.Instance.GetAllProduct().Where(s => s.CategoryID == id).ToList();
            ViewBag.CateId = id;
            int pageNumber = (page ?? 1);
            int pageSizePage = (pageSize ?? 6);
            var listResponse = list.OrderBy(s => s.ProductID).ToPagedList(pageNumber, pageSizePage);
            return PartialView("SearchByCategory", listResponse);
        }


        public ActionResult ShowImage(int id)
        {
            CategoryDTO category = CategoryModel.Instance.GetCategoryById(id);
            var image = category.Picture;
            return File(image, "image/jpg");
        }
    }
}