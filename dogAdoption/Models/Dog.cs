using System;
using System.ComponentModel.DataAnnotations;

namespace dogAdoption.Models
{
    public class Dog 
    {

        [Key]
        public int Id{ get;set; }
        [Required(ErrorMessage = "name is required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string? Name{ get;set; }
        [Required(ErrorMessage = "age is required")]
        public int Age{ get;set; }
        [Required(ErrorMessage = "color is required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string? Color{get;set;}
        [Required(ErrorMessage = "eyes-color is required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string? EyesColor{get;set;}
        [Required(ErrorMessage = "health-condition is required")]
        public string? HealthCondition{get;set;}
        [Required(ErrorMessage = "disability is required")]
        public bool Disability{get;set;}
        [Required(ErrorMessage = "trained-level is required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string? TrainedLevel{get;set;}
        public bool adopted { get;set; }
        public IEnumerable<AdoptionRequest>? adoptionRequest { get;set; }
    }
}