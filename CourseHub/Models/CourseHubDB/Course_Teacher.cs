using CourseHub.Models.CourseDB;

namespace CourseHub.Models.CourseHubDB
{
    public class Course_Teacher
    {
        public int CourseID { get; set; }
        public int TeacherID { get; set; }

        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
    }
}
