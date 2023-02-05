using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dp;

        public CategoryController(ApplicationDbContext dp)
        {
            _dp = dp;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _dp.Categories;  //Gets all records from Category table

            return View(objCategoryList);
        }
    }
}
