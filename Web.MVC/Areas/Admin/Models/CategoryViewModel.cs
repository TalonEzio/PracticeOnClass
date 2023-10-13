using System.ComponentModel.DataAnnotations;

namespace Web.MVC.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "{0} không vượt quá {1} ký tự")]
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "{0} không vượt quá {1} ký tự")]
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Tên tiếng Việt")]
        public string VietnameseName { get; set; }

    }
}