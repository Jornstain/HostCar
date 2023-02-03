using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Host_Car.Models
{
    public class UserData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string SureName { get; set; }

        [Required]
        public int Kimlik { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        public string IdentityUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
