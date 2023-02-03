using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Host_Car.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public string PaymentStatus { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }


    }
}