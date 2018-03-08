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
    public class ProductController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetAllProduct()
        {
            List<ProductDTO> list = db.Products.Select(e => new ProductDTO()
            {
                ProductID = e.ProductID,
                ProductName = e.ProductName,
                CategoryID = e.CategoryID,
                Discontinued = e.Discontinued,
                ReorderLevel = e.ReorderLevel,
                QuantityPerUnit = e.QuantityPerUnit,
                SupplierID = e.SupplierID,
                UnitPrice = e.UnitPrice,
                UnitsInStock = e.UnitsInStock,
                UnitsOnOrder = e.UnitsOnOrder,
                ProductImage = e.ProductImage,
                Category = new CategoryDTO()
                {
                    CategoryID = e.Category.CategoryID,
                    CategoryName = e.Category.CategoryName
                }
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

        public IHttpActionResult GetProductId(int id)
        {
            ProductDTO list = db.Products.Where(a => a.ProductID == id).Select(e => new ProductDTO()
            {
                ProductID = e.ProductID,
                ProductName = e.ProductName,
                CategoryID = e.CategoryID,
                Discontinued = e.Discontinued,
                ReorderLevel = e.ReorderLevel,
                QuantityPerUnit = e.QuantityPerUnit,
                SupplierID = e.SupplierID,
                UnitPrice = e.UnitPrice,
                UnitsInStock = e.UnitsInStock,
                UnitsOnOrder = e.UnitsOnOrder,
                ProductImage = e.ProductImage,
                Category = new CategoryDTO()
                {
                    CategoryID = e.Category.CategoryID,
                    CategoryName = e.Category.CategoryName
                }
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

        public IHttpActionResult PostNewProduct(ProductDTO product)
        {
            Product productInsert = new Product()
            {
                ProductName = product.ProductName,
                CategoryID = product.CategoryID,
                Discontinued = product.Discontinued,
                ReorderLevel = product.ReorderLevel,
                QuantityPerUnit = product.QuantityPerUnit,
                SupplierID = product.SupplierID,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ProductImage = product.ProductImage

            };
            db.Products.Add(productInsert);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutEmployee(ProductDTO product)
        {
            Product productInsert = db.Products.FirstOrDefault(s => s.ProductID == product.ProductID);

            productInsert.ProductName = product.ProductName;
            productInsert.CategoryID = product.CategoryID;
            productInsert.Discontinued = product.Discontinued;
            productInsert.ReorderLevel = product.ReorderLevel;
            productInsert.QuantityPerUnit = product.QuantityPerUnit;
            productInsert.SupplierID = product.SupplierID;
            productInsert.UnitPrice = product.UnitPrice;
            productInsert.UnitsInStock = product.UnitsInStock;
            productInsert.UnitsOnOrder = product.UnitsOnOrder;
            productInsert.ProductImage = product.ProductImage;

     
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(s => s.ProductID == id);
            if (product != null)
            {
                
                db.Products.Remove(product);
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
