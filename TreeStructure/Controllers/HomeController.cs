using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreeStructure.ViewModels;

namespace TreeStructure.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string order)
        {
            var viewModle = new HomeViewModel { Order = order };
            return await Task.FromResult(View(viewModle)); ;
        }
    }
}