using CourseHub.Models.CourseDB;

namespace CourseHub.Models.CourseHubDB
{
    public class Course_Category
    {
        public int CourseID { get; set; }
        public int CategoryID { get; set; }

        public Course Course { get; set; }
        public Category Category { get; set; }
    }
}
