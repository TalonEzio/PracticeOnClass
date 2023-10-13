using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels.EF
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [DataType("nvarchar")]
        public string Name { get; set; }

        [StringLength(50)]
        [DataType("nvarchar")]
        public string VietnameseName { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public DateTime? Deleted { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Product> Products { get; set; }
    }
}
