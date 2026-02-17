using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarnManagement.Model
{
    /*
         * public class AnimalSpecies
         AnimalSpeciesId (int, primary key)
         AnimalSpeciesName (string)
         AnimalSpeciesLifeSpan (int)
         AnimalSpeciesProduction (string)
         */
    public class AnimalSpecies
    {
        

        [Key]
        public int AnimalSpeciesId { get; set; }
        public string AnimalSpeciesName { get; set; } = null!;
        public int AnimalSpeciesLifeSpan { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AnimalSpeciesPurchasePrice { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
