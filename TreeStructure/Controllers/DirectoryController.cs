using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TreeStructure.Services;
using TreeStructure.ViewModels;

namespace TreeStructure.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DirectoryController : Controller
    {
        private readonly IDirectoryService _dirService;

        public DirectoryController(IDirectoryService dirService)
        {
            _dirService = dirService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddNewItemViewComponentModel vm)
        {
            await _dirService.CreateAsync(vm.Name, vm.ParentId);
            return RedirectToAction("Index", "Panel", new { order = vm.Order });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditItemViewComponentModel vm)
        {

            await _dirService.UpdateAsync(vm.Id, vm.NewName, vm.ParentId);
            return RedirectToAction("Index", "Panel", new { order = vm.Order });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RemoveItemViewComponentModel vm)
        {
            if (vm.Confirmed)
                await _dirService.RemoveAsync(vm.Id);
            return RedirectToAction("Index", "Panel", new { order = vm.Order });
        }
    }
}