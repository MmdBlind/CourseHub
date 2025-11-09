using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseHub.Areas.Admin.Models.ViewModels
{
    public class CreateAndEditCategoryViewModel
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string Slug { get; set; }
        
        public int? ParentID { get; set; }
        
        [ValidateNever]
        public List<SelectListItem> ParentOption { get; set; }

        public int CoursesCount { get; set; }
    }
}
