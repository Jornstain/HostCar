using Host_Car.Models.AdressModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Host_Car.Models
{
    public class CarDetail
    {
        [Key]
        public int Id { get; set; }
        public string CarImage { get; set; }
        public int AgePermission { get; set; }
        public int MinimumDriverLicensYear { get; set; }
        public string CarStatus { get; set; }
        public int CarQuantity { get; set; }

        public int CarTypeID { get; set; }
        public virtual CarType CarTypes { get; set; }

        public int CarClassId { get; set; }
        public virtual CarClass CarClasses { get; set; }

        public int FuelTypeId { get; set; }
        public virtual FuelType FuelTypes { get; set; }

        public int CarBrandId { get; set; }
        public virtual CarBrand CarBrands { get; set; }

        public int CarModelId { get; set; }
        public virtual CarModel CarModels { get; set; }

        public int CarPriceId { get; set; }
        public virtual CarPrice CarPrices { get; set; }

    }
}
