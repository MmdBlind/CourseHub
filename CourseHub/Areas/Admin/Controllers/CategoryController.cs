using CourseHub.Areas.Admin.Models.ViewModels;
using CourseHub.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseHub.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private CourseHubContext _context;
        public CategoryController(CourseHubContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var CategoryList = await _context.Categories
                .Select(c => new GetAllCategoriesViewModel
                {
                    ID = c.CategoryID,
                    Name = c.CategoryName,
                    Slug = c.CategorySlug,
                    ParentID = c.CategoryParentID,
                    CoursesCount = c.Course_Categories.Count()
                }).ToListAsync();
            return View();
        }
    }
}
