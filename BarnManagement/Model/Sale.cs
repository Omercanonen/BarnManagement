using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarnManagement.Model
{
    public class Sale
    {
        /*
          public class Sales
         SaleId (int, primary key)
            SaleDate (DateTime)
            SaleAmount (decimal)
            ProductId FK
            IsActive (bool)
        SaleQuantity (int)
        Isactive (bool)
         */

        [Key]
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        public int BarnId { get; set; }
        public Barn Barn { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int SaleQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPriceAtSale { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SaleAmount { get; set; }

        public bool IsActive { get; set; } = true;
        public string? SoldByUserId { get; set; }
    }
}
