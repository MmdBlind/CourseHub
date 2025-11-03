namespace CourseHub.Areas.Admin.Models.ViewModels
{
    public class LatestCourseViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsDelete { get; set; }
        public List<string> Teachers { get; set; }
        public List<string> Categories { get; set; }


    }
}
