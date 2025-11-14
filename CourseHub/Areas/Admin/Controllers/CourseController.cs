using CourseHub.Areas.Admin.Models.ViewModels;
using CourseHub.Models.CourseDB;
using CourseHub.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                .AsNoTracking()
                .Select( c=>new GetAllCoursesViewModel
                {
                    CourseID=c.CourseID,
                    CourseTitle=c.CourseTitle,
                    CourseSlug=c.CourseSlug,
                    CategoryList= _context.Course_Categories
                                    .Where(cc=>cc.CourseID==c.CourseID)
                                    .Select(c=>c.Category.CategoryName)
                                    .FirstOrDefault(),
                    CoursePrice=c.CoursePrice,
                    CoursePublishDate=c.CoursePublishDate,
                    CourseIsDelete=c.CourseIsDelete
                }).ToList();
            return View(CourseList);
        }
    }
}
