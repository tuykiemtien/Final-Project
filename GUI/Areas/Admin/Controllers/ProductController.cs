using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using GUI.Models;
using PagedList;

namespace GUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order == null ? "Id" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var products = ProductModel.Instance.GetAllProduct();

            if (!String.IsNullOrEmpty(Search_Data))
            {
                products = products.Where(s => s.ProductName.ToUpper().Contains(Search_Data.ToUpper())
                    || s.Category.CategoryName.ToUpper().Contains(Search_Data.ToUpper())).ToList();
            }
            switch (Sorting_Order)
            {
                case "Id":
                    products = products.OrderBy(s => s.ProductID).ToList();
                    break;
                case "Product_Name":
                    products = products.OrderBy(s => s.ProductName).ToList();
                    break;
                case "Category":
                    products = products.OrderBy(s => s.Category.CategoryName).ToList();
                    break;
                case "Quantity_Per_Unit":
                    products = products.OrderBy(s => s.QuantityPerUnit).ToList();
                    break;
                case "Unit_Price":
                    products = products.OrderBy(s => s.UnitPrice).ToList();
                    break;
                default:
                    products = products.OrderBy(s => s.ProductID).ToList();
                    break;
            }

            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);

            return View(products.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        public ActionResult Details(int id)
        {
            return View(ProductModel.Instance.GetProductById(id));
        }


        public ActionResult Create()
        {
            ViewBag.ListCategory = CategoryModel.Instance.GetAllCategory();
            return View();
        }

        [HttpPost]
        public JsonResult Create(ProductDTO product,HttpPostedFileBase file)
        {
            ProductDTO lastProduct = ProductModel.Instance.GetAllProduct().LastOrDefault();
            var fileName = "";
            var imageLink = @"~/Upload/Product/";
            product.ProductID = lastProduct.ProductID++;
            if (file != null)
            {
                
                fileName = Path.GetFileName(file.FileName);
                string[] splitName = fileName.Split('.');
                fileName = "Product " + (lastProduct.ProductID + 1) + "." + splitName[1];
                file.SaveAs(HttpContext.Server.MapPath(imageLink) + fileName);
                imageLink += fileName;
            }
            product.ProductImage = imageLink;

            bool check = ProductModel.Instance.InsertNewProduct(product);

            if (check)
            {
                return Json(new { Ok = true });
            }
            else
            {
                return Json(new { Ok = false });
            }
        }

    }
}