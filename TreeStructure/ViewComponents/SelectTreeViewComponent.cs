using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreeStructure.DTO;
using TreeStructure.Services;
using TreeStructure.ViewModels;

namespace TreeStructure.ViewComponents
{
    public class SelectTreeViewComponent : ViewComponent
    {
        private readonly IDirectoryService _directoryService;

        public SelectTreeViewComponent(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(ICollection<DirectoryDto> directories)
        {
            //var dir = directories.ToList<DirectoryDto>().FirstOrDefault();
            var viewModle = new SelectTreeViewComponentModel { SelectDirModel = directories};

            return await Task.FromResult(View(viewModle));
        }
    }
}
