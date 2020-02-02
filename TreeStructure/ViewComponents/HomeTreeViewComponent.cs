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
    public class HomeTreeViewComponent : ViewComponent
    {
        private readonly IDirectoryService _directoryService;

        public HomeTreeViewComponent(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(ICollection<DirectoryDto> directories, bool isFirstCall)
        {
            //var dir = directories.ToList<DirectoryDto>().FirstOrDefault();
            if (isFirstCall)
            {
                directories = _directoryService.GetDirectoryTree(directories);
            }

            var viewModle = new HomeTreeViewComponentModel { DirModel = directories};

            return await Task.FromResult(View(viewModle));
        }
    }
}
