namespace TravelAgency.Domain;

public interface IRoomReader
{
    IReadOnlyList<Room> GetAllRooms();
}

public interface IBookingManager
{
    Booking CreateBooking(Client client, Room room, DateTime checkIn, DateTime checkOut);
    IReadOnlyList<Booking> GetActiveBookings();
    bool CancelBooking(Guid bookingId);
}