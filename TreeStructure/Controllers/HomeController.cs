using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreeStructure.Data.Repository;
using TreeStructure.Models;
using TreeStructure.Services;
using TreeStructure.ViewModels;

namespace TreeStructure.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDirectoryService _dirService;

        public HomeController(IDirectoryService dirService)
        {
            _dirService = dirService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string order)
        {
            var viewModle = new HomeViewModel { Order = order };
            return await Task.FromResult(View(viewModle)); ;
        }
    }
}