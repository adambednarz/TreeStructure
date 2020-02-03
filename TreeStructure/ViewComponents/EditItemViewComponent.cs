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
    public class EditItemViewComponent : ViewComponent
    {
        private readonly IDirectoryService _directoryService;

        public EditItemViewComponent(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync( int id, string name, int? parentId, string order)
        {
            var currentDirector = await _directoryService.GetDirectoryTreeDifference(id);
            var directoryTree = _directoryService.GetDirectoryTree(currentDirector);


            var viewModle = new EditItemViewComponentModel { TreeModel = directoryTree, Id = id,
                ParentId = parentId, NewName = name, Order = order };
            return await Task.FromResult(View(viewModle));
        }
    }
}
