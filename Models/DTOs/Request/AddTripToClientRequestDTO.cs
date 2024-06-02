using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Zadanie7.Models.DTOs.Request;

public class AddTripToClientRequestDTO
{
    [NotNull]
    public string FirstName { get; set; }
    [NotNull]
    public string LastName { get; set; }
    [NotNull]
    public string Email { get; set; }
    [NotNull]
    public string Telephone { get; set; }
    [StringLength(11)]
    public string Pesel { get; set; }
    [NotNull]
    public string IdTrip { get; set; }
    public string TripName { get; set; }
    public DateTime PaymentDate { get; set; }
}