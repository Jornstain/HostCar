using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Host_Car.Models.AdressModels
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public string Years { get; set; }
    }
}
