using System;
using System.ComponentModel.DataAnnotations;

namespace DataModels.EF
{
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal? Price { get; set; } = 0;

        public int? Discount { get; set; } = 0;

        public int? Quantity { get; set; } = 0;

        public int? Rate { get; set; } = 0;

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public DateTime? Deleted { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
