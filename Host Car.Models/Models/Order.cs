using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Host_Car.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        //public virtual UserData UserDatas { get; set; }

        public int CarDetailsId { get; set; }
        public virtual CarDetail CarDetails { get; set; }

        public int PreOrderSearchId { get; set; }
        public virtual ICollection<PreOrderSearch>? PreOrderSearch { get; set; }

        public string IdentityUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }

        public DateTime OrderTime { get; set; }
        public string OrderStatus { get; set; }
    }
}