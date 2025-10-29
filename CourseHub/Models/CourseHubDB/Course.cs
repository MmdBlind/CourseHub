namespace CourseHub.Models.CourseDB
{
    public enum CourseLevel
    {
        Undefined = 0,
        Beginner = 1,
        InterMediate = 2,
        Advanced = 3
    }
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseSlug { get; set; }
        public string CourseDescription { get; set; }
        public Decimal CoursePrice { get; set; }
        public CourseLevel CourseLevel { get; set; }
        public DateTime CoursePublishDate { get; set; }
        public int CourseDurationMinutes { get; set; }
        public string CourseImagePath { get; set; }
        public bool CourseIsDelete { get; set; }
    }
}
