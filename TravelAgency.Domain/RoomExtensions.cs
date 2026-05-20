using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.Domain;

public static class RoomExtensions
{
    public static IEnumerable<Room> FilterByMinPrice(this IEnumerable<Room> rooms, decimal minPrice)
    {
        return rooms
            .Where(r => r.GetPrice() >= minPrice)
            .OrderBy(r => r.GetPrice());
    }
}