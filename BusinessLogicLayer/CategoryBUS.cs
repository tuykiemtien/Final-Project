using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class CategoryBUS
    {
        private static CategoryBUS instance;

        public static CategoryBUS Instance
        {
            get { if (instance == null) instance = new CategoryBUS(); return CategoryBUS.instance; }
            private set => instance = value;
        }

        private CategoryBUS() { }

        public List<CategoryDTO> GetAllCategory()
        {
            List<CategoryDTO> list = CategoryDAO.Instance.GetAllCategory();

            
            return list;
        }

        public CategoryDTO GetCategoryById(int id)
        {
            CategoryDTO list = CategoryDAO.Instance.GetCategoryById(id);

            return list;
        }

        public bool InsertNewCategory(CategoryDTO category)
        {
            return CategoryDAO.Instance.InsertNewCategory(category);
        }

        public bool UpdateCategory(CategoryDTO category)
        {
            return CategoryDAO.Instance.UpdateCategory(category);
        }

        public bool DeleteCategory(int id)
        {
            return CategoryDAO.Instance.DeleteCategory(id);
        }
    }
}
