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
    public class RemoveItemViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id, string order )
        {
            var viewModle = new RemoveItemViewComponentModel { Id = id, Confirmed = false, Order = order };
            return await Task.FromResult(View(viewModle));
        }
    }
}
