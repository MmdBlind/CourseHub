using CourseHub.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CourseHub.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        private CourseHubContext _context;

        public CourseController(CourseHubContext context)
        {
            _context = context;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            var CourseList = _context.Courses
            return View();
        }
    }
}
