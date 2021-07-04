namespace TheMen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int OrderId { get; set; }

        public bool? Dathanhtoan { get; set; }

        public bool? Tinhtranggiaohang { get; set; }

        public DateTime? Ngaydat { get; set; }

        public DateTime? Ngaygiao { get; set; }

        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
