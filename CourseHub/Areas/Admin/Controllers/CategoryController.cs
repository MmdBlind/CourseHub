using CourseHub.Areas.Admin.Models.ViewModels;
using CourseHub.Models.CourseDB;
using CourseHub.Models.CourseHubDB;
using CourseHub.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseHub.Areas.Admin.Controllers
{
    [Area("Admin")]
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
                    ParentName = _context.Categories
                                    .Where(cp => cp.CategoryID == c.CategoryParentID)
                                    .Select(p => p.CategoryName)
                                    .FirstOrDefault(),
                    CoursesCount = c.Course_Categories.Count()
                }).ToListAsync();

            return View(CategoryList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var parentOptions = _context.Categories
                                    .AsNoTracking()
                                    .OrderBy(c => c.CategoryName)
                                    .Select(c => new SelectListItem
                                    {
                                        Value = c.CategoryID.ToString(),   // Value باید string باشد
                                        Text = c.CategoryName
                                    })
                                    .ToList();

            parentOptions.Insert(0, new SelectListItem { Value = null, Text = "بدون والد" });

            var viewModel = new CreateAndEditCategoryViewModel
            {
                ParentOption = parentOptions   // حواست باشه اسم پراپرتی با ویو یکی باشه
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditCategoryViewModel viewModel)
        {
            var transaction=_context.Database.BeginTransaction();
            if (_context.Categories.Where(c => c.CategorySlug == viewModel.Slug.Trim('-')).Any())
            {
                if (viewModel.Name != null && viewModel.Slug != null)
                {
                    Category category = new Category
                    {
                        CategoryName = viewModel.Name,
                        CategorySlug = viewModel.Slug,
                        CategoryParentID = viewModel.ParentID
                    };
                    await _context.Categories.AddAsync(category);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("create");
                }
            }
            else
            {
                return RedirectToAction("create");
            }
        }

    }
}
