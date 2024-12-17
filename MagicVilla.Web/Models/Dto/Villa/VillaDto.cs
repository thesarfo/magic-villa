using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Web.Models.Dto.Villa;

public class VillaDto
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
    public string Details { get; set; }
    
    [Required]
    public double Rate { get; set; }
    
    public int Occupancy { get; set; }
    
    public int Sqft { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public string? ImageLocation { get; set; }
    
    public string Amenity { get; set; }
}