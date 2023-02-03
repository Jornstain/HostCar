using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Host_Car.Models.DTos
{
    public class FeedbackDTO
    {

        [Required(ErrorMessage = "Name is Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is Required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is Required.")]
        public string Message { get; set; }
    }
}