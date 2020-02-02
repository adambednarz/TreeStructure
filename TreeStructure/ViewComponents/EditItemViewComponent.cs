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

        public async Task<IViewComponentResult> InvokeAsync(ICollection<DirectoryDto> directories,  int? parentId, string name, bool isFirstCall)
        {
            if (isFirstCall)
            {
                directories = _directoryService.GetDirectoryTree(directories);
            }

            var viewModle = new EditItemViewComponentModel { EditDirModel = directories, SelectDirModel = directories, ParentId = parentId, NewName = name};
            return await Task.FromResult(View(viewModle));
        }
    }
}
