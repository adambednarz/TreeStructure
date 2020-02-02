using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStructure.DTO;
using TreeStructure.Services;
using TreeStructure.ViewModels;

namespace TreeStructure.ViewComponents
{
    public class AddNewItemViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int? parentId )
        {
            var viewModle = new AddNewItemViewComponentModel { ParentId = parentId, Name = ""};

            return await Task.FromResult(View(viewModle));
        }
    }
}
