using Recruitment.DataLayer;
using Recruitment.Interface;
using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        HRContext db = new HRContext();

        public List<CategoryModel> GetAllCategories()
        {
            List<CategoryModel> _Categories = new List<CategoryModel>();
            var mod = db.Categories.ToList(); 
                foreach (var s in mod)
                {
                    var v = new CategoryModel()
                    {
                        Id = s.Id,
                        Name = s.Name
                    };
                    _Categories.Add(v);
                }
                return _Categories;
        }
        public CategoryModel GetCategory(int id)
        {
            var Category = db.Categories.Find (id);
            var CategoryModel = new CategoryModel()
            {
                Id = Category.Id,
                Name = Category.Name
            };
            return CategoryModel;
        }

    }
}
