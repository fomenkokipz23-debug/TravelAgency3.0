using System;

namespace TravelAgency.Domain;

public class BookingService : IRoomReader, IBookingManager
{
    private readonly HotelCatalog _catalog;

    public event EventHandler<BookingEventArgs>? OnBookingCreated;

    public BookingService()
    {
        _catalog = HotelRegistry.Instance.Catalog; 
        
        _catalog.AddRoom(RoomFactory.CreateRoom("standard", 101, 1200));
        _catalog.AddRoom(RoomFactory.CreateRoom("standard", 102, 1000));
        _catalog.AddRoom(RoomFactory.CreateRoom("suite", 201, 2500));
    }

    public IReadOnlyList<Room> GetAllRooms()
    {
        return _catalog.Rooms;
    }

    public Booking CreateBooking(Client client, Room room, DateTime checkIn, DateTime checkOut)
    {
        if (checkOut <= checkIn)
            throw new InvalidBookingDatesException(checkIn, checkOut);

        var booking = new Booking(client, room, checkIn, checkOut);
        _ = _catalog + booking;

        OnBookingCreated?.Invoke(this, new BookingEventArgs(booking));

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