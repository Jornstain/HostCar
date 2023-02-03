using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Host_Car.Models.AdressModels
{
    public class CarClass
    {
        [Key]
        public int Id { get; set; }
        public string Class { get; set; }
    }
}
