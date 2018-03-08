using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using BusinessLogicLayer;
namespace GUI.Models
{
    public class ProductModel
    {
        private static ProductModel instance;

        public static ProductModel Instance
        {
            get { if (instance == null) instance = new ProductModel(); return ProductModel.instance; }
            private set => instance = value;
        }

        private ProductModel() { }
        public List<ProductDTO> GetAllProduct()
        {
            return ProductBUS.Instance.GetAllProduct();
        }

        public ProductDTO GetProductById(int id)
        {
            return ProductBUS.Instance.GetProductById(id);
        }
        public bool InsertNewProduct(ProductDTO product)
        {
            return ProductBUS.Instance.InsertNewProduct(product);
        }
        public bool UpdateProduct(ProductDTO category)
        {
            return ProductBUS.Instance.UpdateProduct(category);
        }
        public bool DeleteProduct(int id)
        {
            return ProductBUS.Instance.DeleteProduct(id);
        }
    } 
}