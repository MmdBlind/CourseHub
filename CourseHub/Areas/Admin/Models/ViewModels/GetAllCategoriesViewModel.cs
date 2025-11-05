namespace CourseHub.Areas.Admin.Models.ViewModels
{
    public class GetAllCategoriesViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? ParentID { get; set; }
        public int CoursesCount { get; set; }
    }
}
