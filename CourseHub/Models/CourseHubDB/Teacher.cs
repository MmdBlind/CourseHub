namespace CourseHub.Models.CourseHubDB
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherFullName { get; set; }
        public string TeacherBio { get; set; }

        public List<Course_Teacher> Course_Teachers { get; set; } = new();

    }
}
