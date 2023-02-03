using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Host_Car.Models.AdressModels
{
    public class CarPrice
    {
        [Key]
        public int Id { get; set; }
        public decimal StandartPrice { get; set; }
        public decimal OnlinePrice { get; set; }
        public decimal CustomerAdressPrice { get; set; }
    }
}
