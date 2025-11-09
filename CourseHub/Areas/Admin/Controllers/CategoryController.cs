using CourseHub.Areas.Admin.Models.ViewModels;
using CourseHub.Models.CourseDB;
using CourseHub.Models.CourseHubDB;
using CourseHub.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

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
        private async Task FillParentOptionsAsync(CreateAndEditCategoryViewModel viewModel, int? excludeid = null)
        {
            //کوئری پایین  همه دسته هارو بغیر از خود اون دسته درصورتی که درحالت ادیت باشد به عنوان دسته انتخابی والد میاره
            var items = await _context.Categories
                                .AsNoTracking()
                                .Where(c => !excludeid.HasValue || c.CategoryID != excludeid)
                                .OrderBy(c => c.CategoryName)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.CategoryID.ToString(),
                                    Text = c.CategoryName,
                                })
                                .ToListAsync();
            //اینجا ی ایتم برای زمانی که نمیخواد والد داشته باشه ایجاد میشه
            items.Insert(0, new SelectListItem { Value = "", Text = "— بدون والد —" }); // ← OK
            //اینجا ایدی ایتمی که کاربر سکلت کرده رو ایدی شو میگیریم و اگه چیزی انتخاب نکرده بود اون رو روی والد میزاریم
            var selected = viewModel.ParentID?.ToString() ?? "";
            //اینجا با استفاده از حلقه این ایتم رو به عنوان انتخاب شده قرار میدیم
            foreach (var item in items) item.Selected = (item.Value == selected);
            //اینجا لیست رو به ویو مدل پاس میدیم
            viewModel.ParentOption = items;
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
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateAndEditCategoryViewModel();
            await FillParentOptionsAsync(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditCategoryViewModel viewModel)
        {
            var transaction = _context.Database.BeginTransaction();
            // بیرون از LINQ و به‌صورت null-safe
            var slugSafe = (viewModel.Slug ?? string.Empty).Trim('-');

            // کوئری تمیزتر و کاراتر
            var exists = await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.CategorySlug == slugSafe);
            if (exists == false)
            {
                if (viewModel.Name != null && viewModel.Slug != null)
                {
                    Category category = new Category
                    {
                        CategoryName = viewModel.Name,
                        CategorySlug = slugSafe,
                        CategoryParentID = viewModel.ParentID
                    };
                    await _context.Categories.AddAsync(category);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    TempData["ToastMessage"] = "دسته با موفقیت ایجاد شد.";
                    TempData["ToastType"] = "success"; // info / warning / danger
                    TempData["ToastTitle"] = "موفق";
                    return RedirectToAction("index");
                }
                else
                {
                    TempData["ToastMessage"] = "تمامی فیلد ها پرشود.";
                    TempData["ToastType"] = "warning"; // info / warning / danger
                    TempData["ToastTitle"] = "توجه";
                    await FillParentOptionsAsync(viewModel);
                    return View("create", viewModel);
                }
            }
            else
            {
                TempData["ToastMessage"] = "متن اسلاگ تکراری است.";
                TempData["ToastType"] = "danger"; // info / warning / danger
                TempData["ToastTitle"] = "خطا";
                await FillParentOptionsAsync(viewModel);
                return View("create", viewModel);
            }
        }


    }
}
