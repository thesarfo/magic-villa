using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Web.Models.Dto.Villa;

public class VillaCreateDto
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
    public string Details { get; set; }
    
    [Required]
    public double Rate { get; set; }
    
    public int Occupancy { get; set; }
    
    public int Sqft { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public IFormFile? Image { get; set; }
    
    public string Amenity { get; set; }
    
}
