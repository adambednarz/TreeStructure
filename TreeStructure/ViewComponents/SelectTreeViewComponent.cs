using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreeStructure.DTO;
using TreeStructure.ViewModels;

namespace TreeStructure.ViewComponents
{
    public class SelectTreeViewComponent : ViewComponent
    {        
        public async Task<IViewComponentResult> InvokeAsync(ICollection<DirectoryDto> directories, bool isFirstCall, string sign = null)
        {
            if(isFirstCall)
            sign = "";

            sign = sign + " -";
            var viewModle = new SelectTreeViewComponentModel { TreeModel = directories, Sign = sign };
            return await Task.FromResult(View(viewModle));
        }
    }
}
