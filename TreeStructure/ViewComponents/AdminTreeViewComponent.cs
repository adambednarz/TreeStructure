using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStructure.DTO;
using TreeStructure.Services;
using TreeStructure.ViewModels;

namespace TreeStructure.ViewComponents
{
    public class AdminTreeViewComponent : ViewComponent
    {
        private readonly IDirectoryService _directoryService;

        public AdminTreeViewComponent(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(ICollection<DirectoryDto> directories, bool isFirstCall, string order)
        {
            if (isFirstCall)
            {
                var alldirectories = await _directoryService.BrowseAsync();
                if (order == "ascending")
                    alldirectories = alldirectories.OrderBy(x => x.Name).ToList();
                else if (order == "descending")
                    alldirectories = alldirectories.OrderByDescending(x => x.Name).ToList();

                directories = _directoryService.GetDirectoryTree(alldirectories);
            }

            var viewModle = new AdminTreeViewComponentModel { DirModel = directories };
            return await Task.FromResult(View(viewModle));
        }
    }
}
