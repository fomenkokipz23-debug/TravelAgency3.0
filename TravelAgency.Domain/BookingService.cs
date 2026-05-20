namespace TravelAgency.Domain;

public class BookingService : IBookingService
{
    private readonly HotelCatalog _catalog;

    public BookingService()
    {
        _catalog = new HotelCatalog("Horizon Luxury Agency");
        
        _catalog.AddRoom(new StandardRoom(101, 1200, hasBalcony: true));
        _catalog.AddRoom(new StandardRoom(102, 1000, hasBalcony: false));
        _catalog.AddRoom(new SuiteRoom(201, 2500, roomsCount: 2, luxuryTaxPercentage: 0.20m));
        _catalog.AddRoom(new SuiteRoom(202, 4000, roomsCount: 3, luxuryTaxPercentage: 0.30m));
    }

    public IReadOnlyList<Room> GetAllRooms()
    {
        return _catalog.Rooms;
    }

    public Booking CreateBooking(Client client, Room room, DateTime checkIn, DateTime checkOut)
    {
        var booking = new Booking(client, room, checkIn, checkOut);
        
        _ = _catalog + booking;
        
        return booking;
    }

    public IReadOnlyList<Booking> GetActiveBookings()
    {
        return _catalog.Bookings;
    }

    public bool CancelBooking(Guid bookingId)
    {
        var booking = _catalog[bookingId];
        if (booking == null) return false;

        booking.Dispose();
        
        return true;
    }
}