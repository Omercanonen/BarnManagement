using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarnManagement.Model
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

        public int BarnId { get; set; }
        public Barn Barn { get; set; } = null!;

        public int AnimalSpeciesId { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; } = null!;

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; }

        public string? PurchasedByUserId { get; set; }
    }
}
