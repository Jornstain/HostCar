using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Host_Car.Models.AdressModels
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }
        public string OficeAdress { get; set; }
        public string OficeName { get; set; }

        public int OficeTimeId { get; set; }
        public virtual OficeTime OficeTimes { get; set; }

        public int CityId { get; set; }
        public virtual City Cities { get; set; }

    }
}