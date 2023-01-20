namespace ParksApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string State { get; set; }
    public string Type { get; set; }
    public string Terrain { get; set; }
    public string Features { get; set; }
  }
}