using System.ComponentModel.DataAnnotations;

namespace BarnManagement.Model
{
    /*
         * public class Animals
         AnimalId (int, primary key)
         AnimalName (string)
         AnimalGender (string)
         AnimalAge (int)
         IsActive (bool)
         BarnId FK
         AnimalSpeciesId FK
         */
    public class Animal
    {
        
        [Key]
        public int AnimalId { get; set; }
        public string AnimalName { get; set; } = null!;
        public string AnimalGender { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int AgeMonth { get; set; } = 0;       // Oyun ayı
        public bool CanProduce { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public int BarnId { get; set; }
        public Barn Barn { get; set; } = null!;

        public int AnimalSpeciesId { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; } = null!;

    }
}
