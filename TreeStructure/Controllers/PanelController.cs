using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TreeStructure.Data.Repository;
using TreeStructure.Services;

namespace TreeStructure.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private readonly IDirectoryService _dirService;

        public PanelController(IDirectoryService dirService)
        {
            _dirService = dirService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var directories = await _dirService.BrowseAsync();
            return View(directories);
        }

        [HttpGet("delete/directory/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _dirService.RemoveAsync(id);
            return  RedirectToAction("Index", "Home");
        }
    }
}