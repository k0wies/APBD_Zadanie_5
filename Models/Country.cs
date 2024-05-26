namespace Zadanie7.Models;

public class Country
{
    public int IdCountry { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Trip> IdTrips { get; set; }
}