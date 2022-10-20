using Recruitment.Models;
using System.Collections.Generic;

namespace Recruitment.Interface
{
    public interface ICategoryRepository 
    { 
        List<CategoryModel> GetAllCategories();
        CategoryModel GetCategory(int id);
    }
}
