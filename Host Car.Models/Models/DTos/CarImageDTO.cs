using Microsoft.AspNetCore.Http;

namespace Host_Car.Models.DTos
{
    public class CarImageDTO
    {
        public string CarImage { get; set; }
        public IFormFile CarImageFile { get; set; }
    }
}
