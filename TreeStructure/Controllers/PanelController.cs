using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TreeStructure.ViewModels;

namespace TreeStructure.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string order)
        {

            var viewModle = new PanelViewModel { Order = order };
            return await Task.FromResult(View(viewModle)); ;
        }
    }
}