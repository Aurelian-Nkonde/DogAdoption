using System;
using System.ComponentModel.DataAnnotations;

namespace dogAdoption.Models
{
    public class AdoptionRequest
    {
        [Key]
        public int Id{get;set;}
        [Required(ErrorMessage = "first-name is required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string? FirstName{get;set;}
        [Required(ErrorMessage = "last-name is required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string? LastName{get;set;}
        [Required(ErrorMessage = "city is required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string? Adress{get;set;}
        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress)]
        [MinLength(2)]
        [MaxLength(200)]
        public string? Email{get;set;}
        public bool? Accepted { get;set; }
        public Dog? dog { get;set; }
    }
}