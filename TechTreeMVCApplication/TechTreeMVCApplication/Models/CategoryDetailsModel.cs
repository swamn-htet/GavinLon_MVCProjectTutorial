using System.Collections;
using System.Collections.Generic;
using TechTreeMVCApplication.Entities;

namespace TechTreeMVCApplication.Models
{
    public class CategoryDetailsModel
    {
        public IEnumerable<GroupedCategoryItemsByCategoryModel> GroupedCategoryItemsByCategoryModels { get; set; }
        public IEnumerable<Category> Categories { get; set; }


    }
}
