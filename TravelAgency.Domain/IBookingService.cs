namespace TravelAgency.Domain;

public interface IBookingService
{
    IReadOnlyList<Room> GetAllRooms();

    Booking CreateBooking(Client client, Room room, DateTime checkIn, DateTime checkOut);

    IReadOnlyList<Booking> GetActiveBookings();

    bool CancelBooking(Guid bookingId);
}