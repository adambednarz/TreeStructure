using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TreeStructure.Extensionx;
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
            var parentDirectory = await _directoryService.GetAlltTreeNodes();
            var childDirectory = await _directoryService.GetNodeOfFirstLevelChilrenAsync(id);
            var directorDifference = await _directoryService.GetDirectoryTreeDifference(parentDirectory, childDirectory, id);
            var directoryTree = _directoryService.GetDirectoryTree(directorDifference.OrderDirectoryBy(order));

            var viewModle = new EditItemViewComponentModel { TreeModel = directoryTree, Id = id,
                ParentId = parentId, NewName = name, Order = order };
            return await Task.FromResult(View(viewModle));
        }
    }
}
