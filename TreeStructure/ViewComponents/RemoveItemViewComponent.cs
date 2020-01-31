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
        private readonly IDirectoryService _directoryService;

        public RemoveItemViewComponent(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id )
        {

            var viewModle = new RemoveItemComponentModel { Id = id, Confirme = false };
            return await Task.FromResult(View(viewModle));
        }
    }
}
