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
        public async Task<IActionResult> Index()
        {
            var directories = await _dirService.BrowseAsync();
            return View(directories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DirectoryViewModel vm)
        {
            if(vm.ParentId != null)
                await _dirService.CreateByIdAsync(vm.Name, vm.ParentId);
            else
                await _dirService.CreateAsync(vm.Name, vm.ParentName);
         
            return View();
        }
    }
}