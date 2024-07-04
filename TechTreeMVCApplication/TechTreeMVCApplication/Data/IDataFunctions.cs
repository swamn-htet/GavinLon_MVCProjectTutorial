using System.Collections.Generic;
using System.Threading.Tasks;
using TechTreeMVCApplication.Entities;

namespace TechTreeMVCApplication.Data
{
    public interface IDataFunctions
    {
        Task UpdateUserCategoryEntityAsync(List<UserCategory> userCategoryItemsToDelete, List<UserCategory> userCategoryItemsToAdd);
    }
}
