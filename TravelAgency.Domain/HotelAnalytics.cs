using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.Domain;

public class HotelAnalytics
{
    public Dictionary<string, decimal> GetAveragePriceByRoomType(IEnumerable<Room> rooms)
    {
        return rooms
            .GroupBy(r => r.Type)
            .ToDictionary(
                group => group.Key,
                group => group.Average(r => r.GetPrice())
            );
    }

    public decimal GetTotalSpentByClient(IEnumerable<Booking> bookings, Client client)
    {
        return bookings
            .Where(b => b.Guest.Id == client.Id)
            .Sum(b => b.BookedRoom.GetPrice() * (decimal)(b.CheckOut - b.CheckIn).TotalDays);
    }
}