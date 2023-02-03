using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Host_Car.Models.AdressModels
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
    }
}
