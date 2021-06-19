namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? UnitCost { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public int? Size { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        
        public int? ID_Category { get; set; }
        [ForeignKey("ID_Category")]
        public virtual Category Category { get; set; }
    }
}
