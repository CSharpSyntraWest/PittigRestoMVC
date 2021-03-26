using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PittigRestoMVC.Data;
using PittigRestoMVC.Models;
using PittigRestoMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PittigRestoMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubcategoriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubcategoriesController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel();
            model.CategoryList = await _db.Category.ToListAsync();
            model.SubCategory = new SubCategory();
            model.SubCategoryList = await _db.SubCategory.OrderBy(c => c.Name).Select(c => c.Name).Distinct().ToListAsync();
            return View(model);
        }

    }
}
