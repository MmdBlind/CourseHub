using CourseHub.Persistence;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            ViewBag.CourseCount = _context.Courses.Count();
            ViewBag.CategoryCount = _context.Categories.Count();
            ViewBag.TeacherCount = _context.Teachers.Count();

            return View();
        }
    }
}
