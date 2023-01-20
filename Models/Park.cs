using System.ComponentModel.DataAnnotations;

namespace ParksApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    // [Required]
    // [StringLength(60)]
    public string Name { get; set; }
    // [Required]
    // [StringLength(30)]
    public string Location { get; set; }
    // [Required]
    // [StringLength(15)]
    public string State { get; set; }
    // [Required]
    // [MaxLength(60)]
    public string Type { get; set; }
    public string Terrain { get; set; }
    public string Features { get; set; }
  }
}