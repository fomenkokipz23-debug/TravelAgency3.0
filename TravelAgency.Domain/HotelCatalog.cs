namespace TravelAgency.Domain;

public class HotelCatalog
{
    public string HotelName { get; set; }
    private readonly List<Booking> _bookings = new();
    private readonly List<Room> _rooms = new();

    public HotelCatalog(string hotelName)
    {
        HotelName = hotelName;
    }

    public IReadOnlyList<Booking> Bookings => _bookings;
    public IReadOnlyList<Room> Rooms => _rooms;

    public void AddRoom(Room room)
    {
        _rooms.Add(room);
    }

    public Booking? this[Guid bookingId]
    {
        get
        {
            return _bookings.FirstOrDefault(b => b.Id == bookingId);
        }
    }

    public static HotelCatalog operator +(HotelCatalog catalog, Booking newBooking)
    {
        if (newBooking == null) return catalog;

        catalog._bookings.Add(newBooking);
        return catalog;
    }
}