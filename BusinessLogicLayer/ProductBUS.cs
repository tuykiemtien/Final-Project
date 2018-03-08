using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class ProductBUS
    {
        private static ProductBUS instance;

        public static ProductBUS Instance
        {
            get { if (instance == null) instance = new ProductBUS(); return ProductBUS.instance; }
            private set => instance = value;
        }

        private ProductBUS() { }



        public List<ProductDTO> GetAllProduct()
        {
            List<ProductDTO> list = ProductDAO.Instance.GetAllProduct();
            
            return list;
        }

        public ProductDTO GetProductById(int id)
        {
            ProductDTO list = ProductDAO.Instance.GetProductById(id);
           
            return list;
        }

        public bool InsertNewProduct(ProductDTO product)
        {
            return ProductDAO.Instance.InsertNewProduct(product);

        }

        public bool UpdateProduct(ProductDTO product)
        {
            return ProductDAO.Instance.UpdateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return ProductDAO.Instance.DeleteProduct(id);
        }
    }
}
