using CourseHub.Models.CourseDB;

namespace CourseHub.Areas.Admin.Models.ViewModels
{
    public class GetAllCoursesViewModel
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseSlug { get; set; }
        public string CategoryList { get; set; }
        public Decimal CoursePrice { get; set; }
        public DateTime CoursePublishDate { get; set; }
        public bool CourseIsDelete { get; set; }
    }
}
