namespace CourseHub.Areas.Admin.Models.ViewModels
{
    public class CourseViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsDelete { get; set; }
        public string Categories { get; set; }
        public string Teachers { get; set; }


    }
}
