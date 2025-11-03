namespace CourseHub.Areas.Admin.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int CoursesCount { get; set; }
        public int TeachersCount { get; set; }
        public int CategoriesCount { get; set; }
        public List<LatestCourseViewModel> LatestCourseViewModels { get; set; }
    }
}
