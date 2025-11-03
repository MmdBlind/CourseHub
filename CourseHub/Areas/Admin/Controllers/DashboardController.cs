using CourseHub.Areas.Admin.Models.ViewModels;
using CourseHub.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private CourseHubContext _context;
        public DashboardController(CourseHubContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Latestcourses = await _context.Courses
                        .AsNoTracking()
                        .OrderByDescending(c => c.CoursePublishDate)
                        .Take(5)
                        .Select(c=> new LatestCourseViewModel{
                            Title=c.CourseTitle,
                            Slug=c.CourseSlug,
                            Categories=c.Course_Categories
                                .Select(cc=>cc.Category.CategoryName)
                                .ToList(),
                            Teachers=c.Course_Teachers
                                .Select(ct=>ct.Teacher.TeacherFullName)
                                .ToList(),
                            PublishDate=c.CoursePublishDate,
                            IsDelete=c.CourseIsDelete
                        }).ToListAsync();
            DashboardViewModel viewModel = new DashboardViewModel {
                CoursesCount = await _context.Courses.CountAsync(),
                CategoriesCount=await _context.Courses.CountAsync(),
                TeachersCount=await _context.Courses.CountAsync(),
                LatestCourseViewModels=Latestcourses
            }; 
            return View(viewModel);
        }
    }
}
