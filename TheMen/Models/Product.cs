namespace TheMen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(5)]
        public string ProductSize { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public string Description { get; set; }
        public string MadeIn { get; set; }

        public string Brand { get; set; }
        public DateTime DateCapNhat { get; set; }

        public virtual Category Category { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
