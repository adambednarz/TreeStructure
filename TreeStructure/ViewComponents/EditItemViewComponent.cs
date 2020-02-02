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

        public async Task<IViewComponentResult> InvokeAsync( int id, string name, int? parentId)
        {
            var alldirectories = await _directoryService.BrowseAsync();
            var currentDirector = await _directoryService.GetAsync(id);
            var directoryTree = _directoryService.GetDirectoryTree(alldirectories);
            var currentDirectoryTree = _directoryService.GetDirectoryTree(alldirectories, currentDirector);

            var directoriesToDisplay =  directoryTree.Where(x => !currentDirectoryTree.Any(y => y.Id == x.Id)).ToList();


            var viewModle = new EditItemViewComponentModel { EditDirModel = directoryTree, SelectDirModel = directoriesToDisplay, Id = id, ParentId = parentId, NewName = name };
            return await Task.FromResult(View(viewModle));
        }
    }
}
