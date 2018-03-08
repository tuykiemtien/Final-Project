using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
    using BusinessLogicLayer;
namespace GUI.Models
{
    public class CategoryModel
    {
        private static CategoryModel instance;

        public static CategoryModel Instance
        {
            get { if (instance == null) instance = new CategoryModel(); return CategoryModel.instance; }
            private set => instance = value;
        }

        private CategoryModel() { }

        public List<CategoryDTO> GetAllCategory()
        {
            return CategoryBUS.Instance.GetAllCategory();
        }

        public CategoryDTO GetCategoryById(int id)
        {
            return CategoryBUS.Instance.GetCategoryById(id);
        }
        
        public bool InsertNewCategory(CategoryDTO category)
        {
            return CategoryBUS.Instance.InsertNewCategory(category);
        }
        public bool UpdateCategory(CategoryDTO category)
        {
            return CategoryBUS.Instance.UpdateCategory(category);
        }
        public bool DeleteCategory(int id)
        {
            return CategoryBUS.Instance.DeleteCategory(id);
        }
    }
}