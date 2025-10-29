namespace CourseHub.Models.CourseHubDB
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public int? CategoryParentID { get; set; }
    }
}
