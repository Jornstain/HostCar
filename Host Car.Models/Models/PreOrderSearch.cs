using Host_Car.Models.AdressModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Host_Car.Models
{
    public class
        PreOrderSearch
    {
        [Key]
        public int Id { get; set; }

        public int ConfirmAdressId { get; set; }
        public int GiveBackAdressId { get; set; }
        public virtual ICollection<Adress> Adresses { get; set; }

        public Guid SpecialOrderDetailId { get; set; } = Guid.NewGuid();
        public string OrderSearchStatus { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderStartDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderEndDate { get; set; }



    }
}