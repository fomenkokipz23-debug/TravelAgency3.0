using System;

namespace TravelAgency.Domain;

public class BookingDto
{
    public Guid Id { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string ClientEmail { get; set; } = string.Empty;
    public int RoomNumber { get; set; }
    public string RoomType { get; set; } = string.Empty;
    public string CheckInDate { get; set; } = string.Empty;
    public string CheckOutDate { get; set; } = string.Empty;
    public decimal FinalPricePerNight { get; set; }
}