using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarnManagement.Model
{
    /*
        * public class Products
        ProductId (int, primary key)
           ProductName (string)
           ProductQuantity (int)
       ProductPrice (decimal)
       AnimalSpeciesId FK
       IsActive (bool)
        */
    public class Product
    {
       
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

        public int AnimalSpeciesId { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public ICollection<BarnInventory> InventoryItems { get; set; } = new List<BarnInventory>();
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
