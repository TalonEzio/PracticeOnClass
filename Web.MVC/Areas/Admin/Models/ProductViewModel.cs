using System.ComponentModel.DataAnnotations;

namespace Web.MVC.Areas.Admin.Models
{
    public class ProductViewModel
    {
        [Display(Name = "Mã sản phẩm")]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "{0} dài không quá {1} ký tự")]
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "{0} là bắt buộc")]
        public string ImageUrl { get; set; }

        [Display(Name = "Giá sản phẩm ($)")]
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Range(0, 10000, ErrorMessage = "{0} chỉ trong khoảng {1} tới {2}")]
        public decimal? Price { get; set; } = 0;

        [Display(Name = "Giảm giá (%)")]
        [Range(0, 100, ErrorMessage = "{0} chỉ trong khoảng {1} tới {2}")]
        public int? Discount { get; set; } = 0;

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Range(0, 10000, ErrorMessage = "{0} chỉ trong khoảng {0} tới {1}")]
        public int? Quantity { get; set; } = 0;

        [Display(Name = "Đánh giá")]
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Range(0, 5, ErrorMessage = "{0} chỉ trong khoảng {0} tới {1}")]
        public int? Rate { get; set; } = 0;

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "{0} là bắt buộc")]
        public int CategoryId { get; set; }
    }
}