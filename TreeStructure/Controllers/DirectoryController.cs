﻿using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Index(int id)
        {
            var model = await _dirService.GetAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddNewItemComponentModel vm)
        {
            await _dirService.CreateByIdAsync(vm.Name, vm.ParentId);
            return RedirectToAction("Index", "Panel");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RemoveItemComponentModel vm)
        {
            if (vm.Confirmed)
                await _dirService.RemoveAsync(vm.Id);
            return RedirectToAction("Index", "Panel");
        }
    }
}