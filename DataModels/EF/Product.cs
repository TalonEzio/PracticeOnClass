using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.EF
{
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        [DataType("nvarchar")]
        public string Name { get; set; }

        [DataType("nvarchar")]
        public string ImageUrl { get; set; }

        public decimal? Price { get; set; } = 0;

        public int? Discount { get; set; } = 0;

        public int? Quantity { get; set; } = 0;

        public int? Rate { get; set; } = 0;

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public DateTime? Deleted { get; set; }

        public bool IsDeleted { get; set; } = false;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
