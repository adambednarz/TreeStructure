using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TreeStructure.ViewModels;

namespace TreeStructure.ViewComponents
{
    public class AddNewItemViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int? parentId, string order)
        {
            var viewModle = new AddNewItemViewComponentModel { ParentId = parentId, Name = "", Order = order };
            return await Task.FromResult(View(viewModle));
        }
    }
}
