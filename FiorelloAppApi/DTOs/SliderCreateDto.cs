using System.ComponentModel.DataAnnotations;

namespace FiorelloAppApi.DTOs
{
    public class SliderCreateDto
    {
        
            [Required]
            public List< IFormFile> Images { get; set; }
        
    }
}
