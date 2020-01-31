using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TreeStructure.Data.Repository;
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

        [HttpGet()]
        public async Task<IActionResult> Index(int id )
        {
            var model = await _dirService.GetAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DirectoryViewModel vm)
        {
            if(vm.)
            if (vm.ParentId != null)
                await _dirService.CreateByIdAsync(vm.Name, vm.ParentId);
            else
                await _dirService.CreateAsync(vm.Name, vm.ParentName);

            return RedirectToAction("Index", "Panel"); 
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
             await _dirService.RemoveAsync(id);
            return  RedirectToAction("Index", "Panel");
        }
    }
}